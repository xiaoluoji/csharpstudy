using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace csharpstudy
{
    class Car:IComparable<Car>,ICloneable
    {
        public const int MaxSpeed = 100;
        public string petName;
        public int currSpeed;
        private int oilLeft;
        private bool carIsDead;
        public int CarID { get; set; }
        public Car()
        {
        }
        public int Oil
        {
            get { return oilLeft; }
            set { oilLeft = value; }
        }
        public Car(string petName, int currSpeed,int id)
        {
            this.petName = petName;
            this.currSpeed = currSpeed;
            this.CarID = id;
        }
        public Car(string petName,int currSpeed)
        {
            this.petName = petName;
            this.currSpeed = currSpeed;
        }
        public Car(string petName)
            : this("petName",0){ }
        public Car(int currSpeed)
            : this("", currSpeed){ }

        public void ResetCar()
        {
            this.carIsDead = false;
            currSpeed = 10;
        }
        public  string  PrintState()
        {
            return (string.Format("{0} is going {1} MPH. There's {2} L oil left", petName, currSpeed,oilLeft ));
        }
        public string SpeedUp(int delta)
        {
            string afterSpeedUP="";
            if (carIsDead)
            {
                afterSpeedUP = string.Format("{0} is out of order..", petName);
            }
            else
            {
                currSpeed += delta;
                if (currSpeed > MaxSpeed)
                {
                    currSpeed = 0;
                    carIsDead = true;
                    Exception ex= new Exception(string.Format("{0} has overheated!", petName));
                    ex.HelpLink = "http://www.cz25.com";
                    ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot.");
                    throw ex;
                }
                else
                    afterSpeedUP = string.Format("=> currentSpeed = {0}", currSpeed);
            }
            return afterSpeedUP;
        }
        public virtual  void  fixcar()
        {
            Console.WriteLine("Fix this car!");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        int IComparable<Car>.CompareTo(Car  obj)
        {
            //Car temp = obj as Car;
            //if(temp != null)
            //{
                return this.CarID.CompareTo(obj.CarID); //默认使用carID作为排序，
                //return this.petName.CompareTo(temp.petName);  //如果使用此方法则是用petName字段来排序
            //}
            //else
            //{
             //   throw new ArgumentException("Parameter is not a car!");
            //}
        }
        public static IComparer SortByPetName
        {
            get { return (IComparer)new PetNameComparer(); }
        }
        //1）定义委托类型
        public delegate void CarEngineHandler(string msgForCaller,TextBox tboxForCar);
        //2)定义每个委托类型的成员变量
        private CarEngineHandler listOfHandlers;
        //3)向调用者添加注册函数
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToDelete)
        {
            listOfHandlers -= methodToDelete;
        }
        //4)实现Accelerate()方法以再某些情况下调用委托的调用列表
        //如汽车不能用了，出发引爆事件

        public void Accelerate(int delta,TextBox tboxCar)
        {
            if(carIsDead)
            {
                if(listOfHandlers != null)
                {
                    listOfHandlers("Sorry,this car is dead...",tboxCar);
                }
            }
            else
            {
                currSpeed += delta;
                //快不能用了么
                if(10==(MaxSpeed-currSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!",tboxCar);
                }
                if (currSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                } else
                    tboxCar.AppendText(string.Format("CurrentSpeed={0}\n", currSpeed));
            }
        }
        public static void OnCarEngineEvent(string msg, TextBox tboxCar)
        {
            tboxCar.AppendText("*******Message From Car Object*********\n");
            tboxCar.AppendText(string.Format("->{0}\n", msg));
            tboxCar.AppendText("*********************************************\n");
        }
        public static void OnCarEngineEvent2(string msg,TextBox tboxCar)
        {
            tboxCar.AppendText("*******Message From OnCarEngineEvent2*********\n");
        }

        //定义另外一个委托类型
        public class CarEventArgs: EventArgs
        {
            public readonly string msg;
            public CarEventArgs(string message)
            {
                msg = message;
            }
        }
        //public delegate void NewCarEngineHandler(string msgForCaller, TextBox tboxForCar);
        public delegate void NewCarEngineHandler(object sennder, CarEventArgs e, TextBox tboxForCar);

        //通过Event关键词来实现委托调用
        //申明事件，事件是成员！！而不是类型，和方法、属性一样，事件是类或者结构的成员。
        //由于事件是成员：
        //***我们不能在一段可执行代码中申明事件
        //***他必须申明在类或者结构中，和其他成员一样
        //事件被隐式初始化为null。
        //                  委托类型                        事件名称
        public event NewCarEngineHandler Exploded;
        public event NewCarEngineHandler AboutToBlow;
        //public event EventHandler<CarEventArgs> Exploded;
        //public event EventHandler<CarEventArgs> AboutToBlow;
        public void NewAccelerate(int delta, TextBox tboxCar)
        {
            if (carIsDead)
            {
                if (Exploded!= null)
                {
                    Exploded(this,new CarEventArgs("[From Event]: Sorry,this car is dead...\n"), tboxCar);
                }
            }
            else
            {
                currSpeed += delta;
                //快不能用了么
                if (10 == (MaxSpeed - currSpeed) && AboutToBlow != null)
                {
                    AboutToBlow (this,new CarEventArgs("[From Event]: Careful buddy! Gonna blow!\n"), tboxCar);
                }
                if (currSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                    tboxCar.AppendText(string.Format("CurrentSpeed={0}\n", currSpeed));
            }
        }
        //public static void CarAboutToBlow(string msg, TextBox tboxCar)
        public static void CarAboutToBlow(object sender, CarEventArgs e, TextBox tboxCar)
        {
            tboxCar.AppendText(string.Format("->{0}\n", e.msg));
        }
        //public static void CarIsAlmostDoomed(string msg, TextBox tboxCar)
        public static void CarIsAlmostDoomed(object sender, CarEventArgs e, TextBox tboxCar)
        {
            tboxCar.AppendText(string.Format("=>Critical Message from Car : {0}\n", e.msg));
        }
        //public static void CarExploded(string msg, TextBox tboxCar)
        public static void CarExploded(object sender, CarEventArgs e,  TextBox tboxCar)
        {
            if(sender is Car)
            {
                Car c = (Car)sender;
                tboxCar.AppendText(string.Format("Message from Car [{0} ] : {1}\n", c.petName,e.msg));
            }
            else
                tboxCar.AppendText(string.Format("Message from Car : {0}\n", e.msg));

        }

    }  //car 类结束

    public class PetNameComparer:IComparer //将car对象使用petName字段进行排序，注意：此类不在car类里面，而是在外面
    {
        int IComparer.Compare(object x, object y)
        {
            Car t1 = x as Car;
            Car t2 = y as Car;
            return string.Compare(t1.petName, t2.petName);
        }
    }

    //演示Ienumerable 和 ienumerator
    public class Garage
    {
        private Car[] carArray = new Car[4];
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }
        public IEnumerator GetEnumerator()
        {
            //return carArray.GetEnumerator();
            foreach (Car c in carArray)
            {
                yield return c;
            }
        }
        public IEnumerable GetTheCars (bool ReturnReversed)
        {
            if (ReturnReversed)
            {
                for (int i = carArray.Length;i != 0; i--)
                {
                    yield return carArray[i - 1];
                }
            }
            else
            {
                foreach(Car c in carArray)
                {
                    yield return c;
                }
            }
        }

    }

    class DomesticCar : Car //演示继承
    {
        public int Accessory { get; set; }
        public DomesticCar(string carName,int currSpeed,int domesticAcc)
            :base(carName ,currSpeed )
        {
            Accessory = domesticAcc;
        }
        public override void fixcar()
        {
            base.fixcar();
            Console.WriteLine("this is a domestic car!");
        }
    }

    //下面代码演示接口，抽象类
    public interface IDraw3D
    {
        void Draw3D(TextBox tboxTest);
    }

    public interface IDrawToForm
    {
        void Draw(TextBox tboxTest);
    }
    public interface IDrawToMemory
    {
        void Draw(TextBox tboxTest);
    }
    public interface IDrawToPrinter
    {
        void Draw(TextBox tboxTest);
    }

    abstract  class Shape
    {
        public string PetName { get; set; }
        public Shape(string name="NoName")
        {
            PetName = name;
        }
        public virtual void Draw(TextBox tboxTest)
        {
            tboxTest.AppendText("Inside Shape.Draw()\n");
        }
    }

    class Circle : Shape,IDraw3D
    {
        public Circle()
        {

        }
        public Circle(string name):base(name)
        {
                
        }
        public void Draw3D(TextBox tboxTest)
        {
            tboxTest.AppendText("Drawing circle in 3D!\n");
        }
    }
    class Hexagon : Shape
    {
        public Hexagon() { }
        public Hexagon(string name):base(name)
        {
            
        }
        public override void Draw(TextBox tboxTest)
        {
            tboxTest.AppendText(string.Format("Drawing {0} the Hexagon.\n", PetName));
        }
    }

    class Octagon : Shape, IDrawToForm, IDrawToMemory, IDrawToPrinter
    {
        public Octagon()
        {

        }
        public Octagon(string name) : base(name)
        {

        }
        public override void Draw(TextBox tboxTest)
        {
            tboxTest.AppendText("Drawing the Octagon...\n");
        }
        void IDrawToForm.Draw(TextBox tboxTest)
        {
            tboxTest.AppendText("Drawing to form...\n");
        }
        void IDrawToMemory.Draw(TextBox tboxTest)
        {
            tboxTest.AppendText("Drawing to memory..\n");
        }
        void IDrawToPrinter.Draw(TextBox tboxTest)
        {
            tboxTest.AppendText("Drawing to printer..\n");
        }
    }

    //eventhander演示
    //delegate void Handler();
    public class IncrementEventArgs : EventArgs
    {
        public int  InterationCount{ get; set; }
        public IncrementEventArgs()
        {
                
        }
        public IncrementEventArgs(int x)
        {
            InterationCount = x;
        }
    }
    class Incrementer
    {
        public event EventHandler<IncrementEventArgs> CountedADozen;
        public void DoCount()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 12 == 0 && CountedADozen != null)
                {
                    CountedADozen(this, new IncrementEventArgs(i));
                }
            }
        }
    }
    class Dozens
    {
        public int DozensCount { get; set; }
        public List<int> DozensList { get; set; }
        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            DozensList = new List<int>();
            incrementer.CountedADozen += Incrementer_CountedADozen;
        }

        public  void Incrementer_CountedADozen(object sender,IncrementEventArgs e)
        {
            DozensList.Add(e.InterationCount);
            DozensCount++;
        }
    }
    
    class MyReflection
    {
        public static void ListMethods(Type t,TextBox tboxOutput)
        {
            tboxOutput.AppendText("********Methods*****\n");
            //MethodInfo[] mi = t.GetMethods();
            var mi = t.GetMethods();
            foreach(var m in mi)
            {
                //得到返回类型
                string retVal = m.ReturnType.FullName;
                string paramInfo = "( ";
                //得到参数
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    paramInfo+=string.Format("{0} {1}",pi.ParameterType,pi.Name);
                }
                paramInfo += " )";
                tboxOutput.AppendText(string.Format("->{0} {1} {2}\n", retVal,m.Name,paramInfo));
            }
        }
        public static void ListFields(Type t,TextBox tboxOutput)
        {
            tboxOutput.AppendText("********Fields******\n");
            //FieldInfo[] fi = t.GetFields();
            var fi = t.GetFields();
            foreach(var f in fi)
            {
                tboxOutput.AppendText(string.Format("->{0}\n", f.Name));
            }
        }
        public static void ListProbs(Type t, TextBox tboxOutput)
        {
            tboxOutput.AppendText("********Probs******\n");
            var pr = t.GetProperties();
            foreach (var p in pr)
            {
                tboxOutput.AppendText(string.Format("->{0}\n", p.Name));
            }
        }
        public static void ListInterfaces(Type t,TextBox tboxOutput)
        {
            tboxOutput.AppendText("*******Interfaces******\n");
            var ifaces = from i in
                                t.GetInterfaces()
                                select i;
            foreach (var i in ifaces)
            {
                tboxOutput.AppendText(string.Format("->{0}\n",i.Name));
            }
        }
    }

    class MyMultiProcess
    {
        public static void ListAllRunningProcesses(TextBox tboxOutput)
        {
            //得到本机的所有进程，按PID排序
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;
            //输出每个进程的PID和名称
            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PID: {0} \tName: {1} \n", p.Id, p.ProcessName);
                tboxOutput.AppendText(info);
            }
        }
    } 

    //扩展方法必须在顶级类域中，不能被嵌套在某一个类中
    static class MyExtendtion
    {
        //本方法运行任何对对象显示它所处的程序集
        public static void DisplayDefiningAssembly(this object obj, TextBox tboxOutput)
        {
            tboxOutput.AppendText(string.Format("{0} lives here: => {1} \n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name));
        }
        //本方法允许任何整型返回倒置的副本，例如56将返回65
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();
            Array.Reverse(digits);
            string newDigits = new string(digits);
            return int.Parse(newDigits);
        }

    }
}
