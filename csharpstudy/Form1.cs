using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using HtmlAgilityPack;
//using ImageMagick;
using AForge.Imaging;
using System.Diagnostics;
using GraphicsMagick;
using Conversive.PHPSerializationLibrary;
using System.Net;
using System.Net.Sockets;


namespace csharpstudy
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public Form1()  //当前主form的构造函数
        {
            InitializeComponent();
            // 允许跨线程调用
            // 实际开发中不建议这样做的，违背了.NET 安全规范
            CheckForIllegalCrossThreadCalls = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.AppendText("大骚骚就是一个大大大大的骚货哟！\n");
            string dasaosao = string.Format("大骚骚获利 {0:P}", 100);
            textBox1.AppendText(dasaosao+"\n");
            textBox1.AppendText(Environment.OSVersion + "\n");
            textBox1.AppendText(".NET Version" + Environment.Version + "\n");
            textBox1.AppendText(string.Format("Max of int: {0}", int.MaxValue)+"\n");
            foreach (var drive in Environment.GetLogicalDrives())
            {
                textBox1.AppendText(drive+"\n");
            }
            bool b = bool.Parse("True");
            textBox1.AppendText(string.Format("{0}\n",b));
            double d = double.Parse("99.884");
            textBox1.AppendText(d.ToString()+"\n");
            StringBuilder xiaojianjian = new StringBuilder("小贱贱就是个贱人！");
            xiaojianjian.AppendLine("贱人!");
            xiaojianjian.AppendLine("大贱人!");
            xiaojianjian.AppendLine("很贱很贱！");
            textBox1.AppendText(xiaojianjian.ToString()+"\n\n");
            //溢出相关的测试
            try
            {
                byte b1 = 200, b2 = 200;
                byte sum = (byte)Add(b1, b2);
                textBox1.AppendText(sum.ToString()+"\n");
            }
            catch (OverflowException ex)
            {
                textBox1.AppendText(ex.Message + "\n\n");
            }
            byte b3 = 100, b4 = 100;
            byte sum2 = (byte)Add(b3, b4);
            textBox1.AppendText(sum2.ToString() + "\n");
            double dsum = Add(9.3, 4.3);
            textBox1.AppendText(dsum.ToString()+"\n");

            string[] fengsao = { "板板哥","大骚骚","骚亲","骚马匹" };
            foreach (var saoqin in fengsao)
            {
                textBox1.AppendText(saoqin+"  ");
            }
            textBox1.AppendText("\n");
            textBox1.AppendText("\n");
            //枚举相关的测试
            EmpType emp = EmpType.Contractor;
            string empResult = AskForBonus(emp);
            textBox1.AppendText(empResult + "\n");
            textBox1.AppendText(string.Format("EmpType uses a {0} for storage",Enum.GetUnderlyingType (typeof(EmpType)))+"\n");
            textBox1.AppendText("emp is a " + emp.ToString()+"\n");
            textBox1.AppendText(string.Format("{0} = {1}", emp.ToString(), (int)emp)+"\n");
            textBox1.AppendText("\n");

            EvaluateEnum(emp);
            DayOfWeek day = DayOfWeek.Friday;
            EvaluateEnum(day);
            ConsoleColor cc = ConsoleColor.Gray;
            EvaluateEnum(cc);

            //结构相关的测试
            Point p = new Point(50, 60);
            textBox1.AppendText(p.Display() + "\n");

            //其他测试
            int num = 130000;
            int test = num / 200000;
            int test2 = num % 200000;
            textBox1.AppendText(string.Format("130000 / 200000={0}, 130000%200000={1}", test, test2));

        }

        enum EmpType
        {
            Manager, //        =0
            Grunt, //             =1
            Contractor, //     =2
            VicePresident //  =3
        }

        struct Point
        {
            public int X;
            public int Y;

            public Point(int Xpos, int Ypos)
            {
                X = Xpos;
                Y = Ypos;
            }
            public void Increment()
            {
                X++;Y++;
            }
            public void Decrement()
            {
                X--;Y--;
            }
            public string Display()
            {
                return (string.Format("X={0}, Y={1}",X,Y));
            }
        }
        public  void EvaluateEnum(System.Enum e)
        {
            textBox1.AppendText(string.Format("=> Information about {0}", e.GetType().Name)+"\n");
            textBox1.AppendText(string.Format("Underlying storage type:{0}", Enum.GetUnderlyingType(e.GetType()))+"\n");
            Array  enumData = Enum.GetValues(e.GetType());
            textBox1.AppendText(string.Format("This enum has {0} members.", enumData.Length)+"\n");
            for (int i = 0; i < enumData.Length; i++)
            {
                textBox1.AppendText(string.Format("Name:{0}, Values: {0:D}", enumData.GetValue(i))+"\n");
            }
            textBox1.AppendText("\n");

        }

        static string AskForBonus(EmpType e)
        {
            string empResult="";
            switch (e)
            {
                case EmpType.Manager:
                    empResult = "How about stock option instead?";
                    break;
                case EmpType.Grunt:
                    empResult = "You have got to be kidding...";
                    break;
                case EmpType.Contractor:
                    empResult = "You already get enough cash....";
                    break;
                case EmpType.VicePresident:
                    empResult = "Very good,sir!";
                    break;
                default:
                    break;
            }
            return empResult;
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
        static double Add(double x, double y)
        {
            return x + y;
        }
        static long Add(long x, long y)
        {
            return x + y;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Car mycar = new Car("Dongfeng",20);
            mycar.Oil = 10;
            mycar.Oil++;
            string state = mycar.PrintState();
            textBox1.AppendText(state + "\n");
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    state = mycar.SpeedUp(10);
                    textBox1.AppendText(state + "\n");
                }
            }
            catch (Exception carError)
            {
                textBox1.AppendText("****Error!****\n");
                textBox1.AppendText(string.Format("Method:{0}", carError.TargetSite) + "\n");
                textBox1.AppendText(string.Format("Message:{0}", carError.Message) + "\n");
                textBox1.AppendText(string.Format("Source:{0}", carError.Source) + "\n");
                //textBox1.AppendText(string.Format("Stack:{0}", carError.StackTrace + "\n"));
                if (carError.Data != null)
                {
                    foreach (DictionaryEntry de in carError.Data)
                    {
                        textBox1.AppendText(string.Format("-> {0} : {1} ", de.Key, de.Value) + "\n");
                    }
                }
            }
            textBox1.AppendText("\n");
            textBox1.AppendText("******Fun with IEnumerator / IEnumerable *******\n");
            Garage carlot = new Garage();
            foreach (Car  c in carlot)
            {
                textBox1.AppendText(string.Format("Car {0} is running in {1} MPH.", c.petName, c.currSpeed)+"\n");
            }
            textBox1.AppendText("Get cars in reverse order:\n");
            foreach(Car c in carlot.GetTheCars(true))
            {
                textBox1.AppendText(string.Format("Car {0} is running in {1} MPH.", c.petName, c.currSpeed) + "\n");
            }
            textBox1.AppendText("******END  of  Fun with IEnumerator / IEnumerable *******\n");
            
            Circle cir = new Circle("Cindy");
            cir.Draw(textBox1);
            if (cir is IDraw3D){
                DrawIn3d(cir);
            }
            Hexagon hex = new Hexagon("Beth");
            hex.Draw(textBox1);

            Octagon oct = new Octagon("Octagon");
            IDrawToForm itfForm = (IDrawToForm)oct;
            itfForm.Draw(textBox1);
            IDrawToMemory itfMemory = (IDrawToMemory)oct;
            itfMemory.Draw(textBox1);
            IDrawToPrinter itfPrinter = (IDrawToPrinter)oct;
            itfPrinter.Draw(textBox1);

            textBox1.AppendText("********Fun with Object Sorting*********\n");
            Car[] myAutos = new Car[5];
            myAutos[0] = new Car("Rusty", 80, 1);
            myAutos[1] = new Car("Mary", 40, 234);
            myAutos[2] = new Car("Viper", 40, 34);
            myAutos[3] = new Car("Mel", 40, 4);
            myAutos[4] = new Car("Chucky", 40, 5);
            foreach (Car c in myAutos) 
            {
                textBox1.AppendText(string.Format("car ID:{0}  petName:{1}",c.CarID,c.petName)+"\n");
            }
            textBox1.AppendText("\n");
            textBox1.AppendText("after sorted by carID :\n");
            Array.Sort(myAutos);
            foreach (Car c in myAutos)
            {
                textBox1.AppendText(string.Format("car ID:{0}  petName:{1}", c.CarID, c.petName)+"\n");
            }
            textBox1.AppendText("\n");
            textBox1.AppendText("after sorted by petName :\n");
            //Array.Sort(myAutos, new PetNameComparer());
            Array.Sort(myAutos, Car.SortByPetName);
            foreach (Car c in myAutos)
            {
                textBox1.AppendText(string.Format("car ID:{0}  petName:{1}", c.CarID, c.petName) + "\n");
            }
        }

        public void DrawIn3d(IDraw3D itf3d)
        {
            itf3d.Draw3D(textBox1);
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "First", "Second", "Third" });
            textBox1.AppendText(string.Format("This collection has {0} items.\n", strArray.Count));
            strArray.Add("Fourth!");
            textBox1.AppendText(string.Format("This collection has {0} items.\n", strArray.Count));
            foreach (string s in strArray)
            {
                textBox1.AppendText(string.Format("Entry:{0}\n", s));
            }
            textBox1.AppendText("******Fun with Collection Generics ******\n");
            //List<>只能容纳car对象
            List<Car> moreCars = new List<Car>();
            moreCars.Add(new Car("Buick", 45, 9));
            moreCars.Add(new Car("Changcheng", 50, 11));
            foreach (Car oneCar in moreCars)
            {
                textBox1.AppendText(string.Format("ID: {0} Car:{1} is running in Speed {2} MPH.\n", oneCar.CarID, oneCar.petName, oneCar.currSpeed));
            }
            textBox1.AppendText("\n");
            textBox1.AppendText("********Fun with ObservableCollection******\n");
            ObservableCollection<Car> myautos = new ObservableCollection<Car>()
            {
                new Car("Buick",60,10),
                new Car("Changcheng",50,11),
                new Car("Jili",40,5),
                new Car("Qirui",50,3)
            };
            myautos.CollectionChanged += Myautos_CollectionChanged;
            myautos.Add(new Car() { petName = "Xiali", CarID = 20, currSpeed = 35 });
            myautos.Add(new Car("Changan", 60, 6));
            myautos.Add(new Car() { petName = "Fiat", CarID = 1, currSpeed = 70});
            myautos.Add(new Car("Bentian", 60, 18));
            myautos.RemoveAt(1);
            textBox1.AppendText("\n");
            textBox1.AppendText("输出添加或删除以后的myautos：\n");
            textBox1.AppendText("\n");

            foreach (Car oneCar in myautos)
            {
                textBox1.AppendText(string.Format("ID: {0} Car:{1} is running in Speed {2} MPH.\n", oneCar.CarID, oneCar.petName, oneCar.currSpeed));
            }

        }

        private void Myautos_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            textBox1.AppendText(string.Format("Action for this event:{0}\n", e.Action));
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                textBox1.AppendText("Here are the OLD items.:\n");
                foreach (Car oneCar in e.OldItems)
                {
                    textBox1.AppendText(string.Format("ID: {0} CarName:{1} Speed {2}\n", oneCar.CarID, oneCar.petName, oneCar.currSpeed));
                }
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                textBox1.AppendText("Here are the new items:\n");
                foreach (Car oneCar in e.NewItems)
                {
                    textBox1.AppendText(string.Format("ID: {0} CarName:{1} Speed {2}\n", oneCar.CarID, oneCar.petName, oneCar.currSpeed));
                }
            }
        }

        delegate int OtherDel(int InParam);
        private void btnDelegate_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.AppendText("*******Fun with Action and Fun******\n");
            //使用Action<>委托向DisplayMessage发送消息
            Action<string, TextBox> actionTarget = new Action<string, TextBox>(DisplayMessage);
            actionTarget("This is a test for Action<>!", textBox1);
            Func<int,int,int> funcTarget= new Func<int, int, int>(AddFun);
            int result=funcTarget(40, 40);
            textBox1.AppendText(string.Format("40+40={0}\n", result));
            Func<int, int, string> funcTargetString = new Func<int, int, string>(SumToString ) ;
            string sum=funcTargetString(90, 300);
            textBox1.AppendText("This is a test for Func<>!\n");
            textBox1.AppendText(sum + "\n");
            textBox1.AppendText("\n");
            //匿名方法测试
            OtherDel del = delegate (int x)
              {
                  return x + 20;
              };
            textBox1.AppendText(string.Format("这是匿名方法的测试 :x=20 (x+20)={0} \n", del(20)));
            textBox1.AppendText(string.Format("这是匿名方法的测试 : x=5  (x+20)={0} \n", del(5)));
            //Lambda表达式
            //**Lambda表达式参数列表中的参数必须在参数数量、类型和位置上与委托相匹配
            //**表达式的参数例表中的参数不一定需要包含类型（隐式类型），除非委托有ref或out参数----此时必须注明类型（显示类型）
            //**如果只有一个参数，并且是隐式类型的，周围的圆括号可以被省略，否则必须有括号。
            //**如果没有参数，必须使用一组空的圆括号。
            OtherDel le1 = (int x) => { return x + 1; };
            OtherDel le2 = (x) => { return x + 2; };
            OtherDel le3 = x => { return x + 3; };
            OtherDel le4 = x => x + 4;       // 只有一个隐式参数，可以省略圆括号
            textBox1.AppendText(string.Format("这是lambda表达式的测试 :x=20 (x+1)={0} \n", le1(20)));
            textBox1.AppendText(string.Format("这是lambda表达式的测试 :x=20 (x+2)={0} \n", le2(20)));
            textBox1.AppendText(string.Format("这是lambda表达式的测试 :x=20 (x+3)={0} \n", le3(20)));
            textBox1.AppendText(string.Format("这是lambda表达式的测试 :x=20 (x+4)={0} \n", le4(20)));


            textBox1.AppendText("*****Delegates as event enablers *****\n");
            Car c1 = new Car("Changan", 10, 10);
            //现在，告诉汽车，它想要向我们发送信息时调用哪个方法,这里绑定了两个
            //c1.RegisterWithCarEngine(new Car.CarEngineHandler(Car.OnCarEngineEvent));
            c1.RegisterWithCarEngine(Car.OnCarEngineEvent);
            Car.CarEngineHandler handle2 = new Car.CarEngineHandler(Car.OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handle2);
            //加速（这将触发事件）
            textBox1.AppendText("*****Speeding up********\n");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20,textBox1);
            }
            //现在注销第二个绑定委托对象
            c1.UnRegisterWithCarEngine(handle2);
           //接下来看不到第二个绑定委托对象的消息了
            textBox1.AppendText("*****Speeding up********\n");
            c1.ResetCar();
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20, textBox1);
            }

            //演示通过Event关键词来实现委托
            textBox1.AppendText("\n");
            textBox1.AppendText("*******Fun with Events******\n");
            Car newCar = new Car("Qirui", 10, 11);
            //为newCar对象的事件绑定方法（方法是Car类的3个静态方法）
            newCar.AboutToBlow += Car.CarIsAlmostDoomed;
            newCar.AboutToBlow += Car.CarAboutToBlow;

            newCar.Exploded += Car.CarExploded;
            textBox1.AppendText("*****Speeding up********\n");
            for (int i = 0; i < 6; i++)
            {
                newCar.NewAccelerate(20, textBox1);
            }
            //从调试列表中移出CarExploded方法
            newCar .Exploded-= Car.CarExploded;
            textBox1.AppendText("After remove newCar.Exploded Event (Car.CarExploded) \n");
            textBox1.AppendText("*****Speeding up********\n");
            newCar.ResetCar();
            for (int i = 0; i < 6; i++)
            {
                newCar.NewAccelerate(20, textBox1);
            }

            //演示C#图解教程中的事件示例
            textBox1.AppendText("\n");
            textBox1.AppendText("**********演示C#图解教程中的事件示例********\n");
            Incrementer incrementer = new Incrementer();
            Dozens dozensCounter = new Dozens(incrementer);
            incrementer.DoCount();
            foreach (int dozeon in  dozensCounter.DozensList)
            {
                textBox1.AppendText(string.Format("Incremented at iteration:{0}\n",dozeon));
            }
            textBox1.AppendText(string.Format("Number of dozens( between 1 and 100) ={0}\n",dozensCounter.DozensCount));

            //演示List<t> 中的FindAll方法
            textBox1.AppendText("\n");
            textBox1.AppendText("**********演示List<t> 中的FindAll方法********\n");
            TranditionalDelegateSyntax(textBox1);

        }
        //泛型委托中的例子
        //Action<>委托的一个目标
        static void DisplayMessage(string msg,TextBox tboxTest)
        {
            tboxTest.AppendText(string.Format("Action<>{0}: \n",msg));
        }
        static int AddFun(int x,int y)
        {
            return x + y;
        }
        static string SumToString(int x,int y)
        {
            return (x + y).ToString();
        }
        //演示TranditionalDelegateSyntax
        static void TranditionalDelegateSyntax(TextBox tboxTest)
        {
            //创建整数列表
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            //Predicate<int> callback = new Predicate<int>(IsEvenNumber);
            //List<int> evenNumbers = list.FindAll(callback);
            //List<int> evenNumbers = list.FindAll(delegate (int i) { return (i % 2) == 0; });

            //*****Lambda表达式可以应用于任何匿名方法或者强类型委托可以应用的场合****
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);
            tboxTest.AppendText("Here are your even numbers:\n");
            foreach (int evenNumber in evenNumbers)
            {
                tboxTest.AppendText(string.Format("{0}\t", evenNumber));
            }
            tboxTest.AppendText("\n");
        }

        static bool IsEvenNumber(int i)
        {
            //这是一个偶数么？
            return (i % 2) == 0;
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            //演示高级语言特性
            textBox1.Text = "";
            textBox1.AppendText("******Fun with Extension methods******\n");
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly(textBox1);
            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly(textBox1);
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly(textBox1);
            Car myCar = new Car("Buick", 80, 10);
            myCar.DisplayDefiningAssembly(textBox1);
            //使用整数的新功能
            textBox1.AppendText(string.Format("{0} reversed {1}\n",myInt,myInt.ReverseDigits()));

            //匿名类型
            var person = new { Name = "大骚骚", Sex = "男", NickName = "骚马屁" };
            textBox1.AppendText(string.Format("匿名类型演示: \n 姓名：{0} 性别：{1} 昵称: {2} \n", person.Name, person.Sex, person.NickName));
            ReflectOverAnonymousType(person, textBox1);
        }

        static void ReflectOverAnonymousType(object obj,TextBox tboxOutput)
        {
            tboxOutput.AppendText(string.Format("obj is an instance of : {0}\n", obj.GetType().Name));
            tboxOutput.AppendText(string.Format("Base class of {0} is {1}\n",obj.GetType().Name,obj.GetType().BaseType));
            tboxOutput.AppendText(string.Format("obj.ToString() == {0}\n", obj.ToString()));
            tboxOutput.AppendText(string.Format("obj.GetHashCode()=={0}\n", obj.GetHashCode()));
        }

        private void btnLinq_Click(object sender, EventArgs e)
        {
            //linq的相关演示
            textBox1.Text = "";
            textBox1.AppendText("************Fun with linq**********\n");
            LinqStudy(textBox1);
        }
        public class Student
        {
            public int StID;
            public string LastName;
        }
        public class CourseStudent
        {
            public string CourseName;
            public int StID;
        }
        static void LinqStudy(TextBox tboxOutput)
        {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;
            foreach (string s in subset)
            {
                tboxOutput.AppendText(string.Format("Item:{0}\n", s));
            }
            int[] myInt = { 2, 5, 9, 15, 20, 23, 26, 29, 31, 33, 36, 39, 40, 45 };
            var lowNum = from num in myInt
                         where num < 30
                         orderby num
                         select num;
            tboxOutput.AppendText(string.Format("Numbers < 30: \n"));
            foreach (int num in lowNum)
            {
                tboxOutput.AppendText(string.Format("{0} ", num));
            }
            tboxOutput.AppendText("\n");
            tboxOutput.AppendText(string.Format("Counts:{0}\n", lowNum.Count()));
            //修改数组成员后再一次遍历（演示：延迟执行）
            myInt[0] = 60;
            tboxOutput.AppendText(string.Format("Numbers < 30: \n"));
            foreach (int num in lowNum)
            {
                tboxOutput.AppendText(string.Format("{0} ", num));
            }
            tboxOutput.AppendText("\n");
            tboxOutput.AppendText(string.Format("Counts:{0}\n", lowNum.Count()));
            tboxOutput.AppendText("返回结果集lowNum的属性：\n");
            ReflectOverAnonymousType(lowNum,tboxOutput); //查看查寻返回的 lowNum实例的相关属性；
            tboxOutput.AppendText("\n");

            //联结查寻
            tboxOutput.AppendText("下面演示联结查寻：\n");
            Student[] students = new Student[]
            {
               new Student {StID=1,LastName="Carson" },
               new Student {StID=2,LastName="Klassen" },
               new Student {StID=3,LastName="Fleming" },
            };
            CourseStudent[] studentsInCourses = new CourseStudent[]
            {
                new CourseStudent {CourseName="Art",StID=1 },
                new CourseStudent {CourseName="Art",StID=2 },
                new CourseStudent {CourseName="History",StID=1 },
                new CourseStudent {CourseName="History",StID=3 },
                new CourseStudent {CourseName="Physics",StID=3 },
            };
            var query = from s in students
                        join c in studentsInCourses on s.StID equals c.StID
                        where c.CourseName == "History"
                        select s.LastName;
            foreach (var q in query)
                tboxOutput.AppendText(string.Format("Student taking History:{0} \n", q));

            //linq查寻应用于非泛型集合
            ArrayList arrayStudents = new ArrayList()
            {
                   new Student {StID=1,LastName="Carson" },
                   new Student {StID=2,LastName="Klassen" },
                   new Student {StID=3,LastName="Fleming" },
            };
            ArrayList arrayStudentsInCourses = new ArrayList()
            {
                    new CourseStudent {CourseName="Art",StID=1 },
                    new CourseStudent {CourseName="Art",StID=2 },
                    new CourseStudent {CourseName="History",StID=1 },
                    new CourseStudent {CourseName="History",StID=3 },
                    new CourseStudent {CourseName="Physics",StID=3 },
            };
            //将ArrayList转换成一个兼容IEnumerable<T>的类型
            var enumStudents = arrayStudents.OfType<Student>();
            var enumStudentsInCourses = arrayStudentsInCourses.OfType<CourseStudent>();
            var queryArt = from s in enumStudents
                           join course in enumStudentsInCourses on s.StID equals course.StID
                           where course.CourseName == "Art"
                           select s.LastName;
            foreach (var q in queryArt)
                tboxOutput.AppendText(string.Format("Student taking Art:{0}\n", q));
            //演示linq的相关工具
            List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
            var carDiff = (from c in myCars select c).Except(from y in yourCars select y);
            tboxOutput.AppendText("\n");
            tboxOutput.AppendText("演示linq的相关工具\n");
            foreach (var item in carDiff)
            {
                tboxOutput.AppendText(string.Format("myCars and yourCars 不同之处：{0}\n",item));
            }
           
        }//end of  LinqStudy()

        private void btnReflection_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            MyReflection.ListMethods(typeof(Car),textBox1);
            MyReflection.ListFields(typeof(Car), textBox1);
            MyReflection.ListProbs(typeof(Car), textBox1);
            MyReflection.ListInterfaces(typeof(Car), textBox1);
        }


        private delegate int BinaryOp(int x, int y);
        private delegate void delegatePrintnumbers();
        class AddParams
        {
            public int x { get; set; }
            public int y { get; set; }
            public AddParams(int a,int b)
            {
                x = a;
                y = b;
            }
        }
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        private object threadlock = new object();
        private void btnMultiProcess_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //输出所有的进程
            textBox1.AppendText("*****Fun with multiprocess****\n");
            //MyMultiProcess.ListAllRunningProcesses(textBox1);

            //输出正在执行中的线程ID
            textBox1.AppendText("******Synch Delegate Review*****\n");
            textBox1.AppendText(string.Format("Main() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId));
            //在同步模式下调用Add()
            BinaryOp b = new BinaryOp(NewAdd);
            BinaryOp c = new BinaryOp(Multiple);

            //也能写成 b.Invoke(10,10);
            //int answer = b(10, 10,textBox1);
            //直到Add()方法完成以后，这行代码才会执行；
            //textBox1.AppendText("Doing more wok in Main()!\n");

            //在次线程中调用Add()
            // IAsyncResult iftAR = b.BeginInvoke(10, 10, new AsyncCallback(AddComplete), null);
            //IAsyncResult iftAR = b.BeginInvoke(10, 10, AddComplete, null);

            /*
            //使用子线程来实现委托调用
            b.BeginInvoke(10, 10, AddComplete, null);
            c.BeginInvoke(10, 10, MultipleComplete, null);

            //执行不带参数的子线程
            Thread backgroundThread = new Thread(new ThreadStart(testFor));
            backgroundThread.Name = "TestFor";
            backgroundThread.Start();
            //执行带参数的子线程
            AddParams addParams = new AddParams(232, 78998);
            Thread backgroundThread = new Thread(new ParameterizedThreadStart(AddWithParams));
            backgroundThread.Start(addParams);
            */
            //演示System.Threading.Timer 类型
            //TimerCallback timeCB = new TimerCallback(PrintTime);
            System.Threading.Timer timer = new System.Threading.Timer(
                //timeCB,
                PrintTime,      //TimerCallBack委托对象
                /*delegate {
                    this.Invoke((Action)delegate { labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()); });
                },*/
                //(object state)=>labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString()),
                null,           //想传入的参数 （null表示没有参数）
                0,              //在开始之前，等待多长时间（以毫秒为单位）
                1000);       //每次调用的间隔时间（以毫秒为单位）
            
            /*
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(new ThreadStart(testFor));
                threads[i].Name = string.Format("Worker thread #{0}\n",i);
            }
            foreach (Thread t in threads)
            {
                t.Start();
            }
            */
            //WaitCallback workItem = new WaitCallback(PrintNumbers);
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintNumbers, null);
                //ThreadPool.QueueUserWorkItem(workItem, null);
            }
            
            AddParams addParams = new AddParams(123, 22);
            //WaitCallback addItem = new WaitCallback(AddWithParams);
            ThreadPool.QueueUserWorkItem(AddWithParams, addParams);
            //ThreadPool.QueueUserWorkItem(addItem, addParams);

            textBox1.AppendText("All tasks queued!\n");

            // 加上下面等待线程完成方法以后，主UI线程就会假死
            /*waitHandle.WaitOne();
            textBox1.AppendText("AddWithParams() work done!!\n");
            */

        }
        private void PrintTime(object state)
        {
            labTime.Text = string.Format("Time is {0}\n", DateTime.Now.ToLongTimeString());
        }
        private void testFor()
        {
            //lock (this)
            lock(threadlock)
            {
                //显示Thread信息
                textBox1.AppendText(string.Format("->{0} is executing testFor()\n", Thread.CurrentThread.Name));
                textBox1.AppendText("Your numbers: ");
                for (int i = 0; i < 10; i++)
                {
                    //使线程休眠数秒
                    Random r = new Random();

                    var rnum = r.Next(3);
                    //textBox1.AppendText(string.Format(" ( t: {0} f: {1} r: {2}  )", Thread.CurrentThread.Name, i, rnum));
                    Thread.Sleep(1000 * rnum);
                    textBox1.AppendText(string.Format("{0} , ", i));
                }
                textBox1.AppendText("\n");
            }

        }  
        private void PrintNumbers(object state)
        {
            //lock (this)
            lock (threadlock)
            {
                //显示Thread信息
                textBox1.Invoke((Action)delegate
                {
                    textBox1.AppendText(string.Format("->{0} is executing testFor()\n", Thread.CurrentThread.Name));
                    textBox1.AppendText("Your numbers: ");
                });
                for (int i = 0; i < 10; i++)
                    {
                        //使线程休眠数秒
                        Random r = new Random();
                        var rnum = r.Next(3);
                        //textBox1.AppendText(string.Format(" ( t: {0} f: {1} r: {2}  )", Thread.CurrentThread.Name, i, rnum));
                        Thread.Sleep(1000 * rnum);
                    textBox1.Invoke((Action)delegate
                    {
                        textBox1.AppendText(string.Format("{0} , ", i));
                    });
                }
                textBox1.Invoke((Action)delegate
                {
                    textBox1.AppendText("\n");
                });

                
                /*
                int[] rnum=new int[10];
                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    rnum[i] = r.Next(3);
                }
                
                Parallel.ForEach(rnum, num => {
                    Thread.Sleep(1000 * num);
                    textBox1.AppendText(string.Format("{0} ,", num));
                });
                */

            }
        }
        private void AddWithParams(object data)
        {
            lock (threadlock)
            {
                if (data is AddParams)
                {
                    Thread.Sleep(7000);
                    textBox1.Invoke((Action)delegate
                    {
                        textBox1.AppendText(string.Format("ID of thread in AddWithParams() is : {0}\n", Thread.CurrentThread.ManagedThreadId));
                        AddParams ap = (AddParams)data;
                        textBox1.AppendText(string.Format("{0} + {1} is {2} \n", ap.x, ap.y, ap.x + ap.y));
                    });

                    //通知其他线程，该线程已经结束
                    //waitHandle.Set();
                }
            }
            
        }
        private int NewAdd(int x,int y)
        {
            //tboxOutput.AppendText(string.Format("NewAdd() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId));
            Thread.Sleep(5000);
            return x + y;
        }
        private int Multiple(int x,int y)
        {
            Thread.Sleep(1000);
            return x * y;
        }
        private void AddComplete(IAsyncResult itfAR)
        {
            textBox1.AppendText(string.Format("AddComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId));
            textBox1.AppendText("Your addition is complete\n");
            //现在得到结果
            //AsyncResult ar = (AsyncResult)itfAR;
            //BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            BinaryOp b = (BinaryOp)((AsyncResult)itfAR).AsyncDelegate;
            //Console.WriteLine("10+10 is {0}.", b.EndInvoke(itfAR));
            int c = b.EndInvoke(itfAR);
            textBox1.AppendText(string.Format("10+10 is {0}\n", c));
        }
        private void MultipleComplete(IAsyncResult itfAR)
        {
            textBox1.AppendText(string.Format("MultipleComplete() invoked on thread {0}\n", Thread.CurrentThread.ManagedThreadId));
            textBox1.AppendText("Your multiple is complete\n");
            //现在得到结果
            //AsyncResult ar = (AsyncResult)itfAR;
            //BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            BinaryOp b = (BinaryOp)((AsyncResult)itfAR).AsyncDelegate;
            //Console.WriteLine("10+10 is {0}.", b.EndInvoke(itfAR));
            int c = b.EndInvoke(itfAR);
            textBox1.AppendText(string.Format("10*10 is {0}\n", c));
        }

        //多线程（二）演示代码
        private readonly int Max_Item_Count = 10000;
        private void btnNewMultiprocess_Click(object sender, EventArgs e)
        {
            
            new Thread((ThreadStart)(delegate (){
                for (int i = 0; i < Max_Item_Count; i++)
                {
                    textBox1.Invoke((MethodInvoker)delegate ()
                    {
                        textBox1.AppendText(string.Format("This is test number: {0}\n",i));
                    });
                }   
            })).Start();
           
            /*
            for (int i = 0; i < Max_Item_Count; i++)
            {
                textBox1.AppendText(string.Format("This is test number: {0} \n", i));
            }
            */
        }

        private void btnFileInput_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.AppendText("*******Fun with File input*****\n");
            //ShowWindowsDirectoryInfo();
            SimpleFileIO();
            FileStreams();
            SerializeTest();
        }
        private void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\testpic\modified");
            //DirectoryInfo newDir= dir.CreateSubdirectory(@"2012\05\12");
            Directory.CreateDirectory(@"D:\testpic\modified\2012\05\12");
            DirectoryInfo newDir = new DirectoryInfo(@"D:\testpic\modified\2012\05\12");
            //获取所有*.jpg文件
            textBox1.AppendText(string.Format("New DIR is: {0}\n",newDir.FullName));
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            textBox1.AppendText("***Directory info******\n");
            textBox1.AppendText(string.Format("FullName: {0}\n",dir.FullName));
            textBox1.AppendText(string.Format("Name: {0}\n", dir.Name));
            textBox1.AppendText(string.Format("Parent: {0}\n", dir.Parent));
            textBox1.AppendText(string.Format("Creation: {0}\n", dir.CreationTime));
            textBox1.AppendText(string.Format("Attributes: {0}\n", dir.Attributes));
            textBox1.AppendText(string.Format("Root: {0}\n", dir.Root));
            textBox1.AppendText("***************************\n");

            textBox1.AppendText(string.Format("Found {0} *.jpg files.\n", imageFiles.Length));
            //输出每个文件的信息
            foreach (var f in imageFiles)
            {
                textBox1.AppendText("**************************\n");
                textBox1.AppendText(string.Format("File Name: {0} \n", f.Name));
                textBox1.AppendText(string.Format("File size: {0}\n", f.Length));
                textBox1.AppendText(string.Format("Creation: {0} \n", f.CreationTime));
                textBox1.AppendText(string.Format("Attributes: {0}\n", f.Attributes));
                textBox1.AppendText("***************************\n");
            }

        }
        private void SimpleFileIO()
        {
            textBox1.AppendText("******Simple I/O with File Type *******\n");
            string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom dan Dad", "Play Xbox 360" };
            File.WriteAllLines(@"d:\tasks.txt", myTasks);
            foreach (var task in File.ReadAllLines(@"d:\tasks.txt")) 
            {
                textBox1.AppendText(string.Format("TODO: {0} \n", task));
            }
        }
        private void FileStreams()
        {
            textBox1.AppendText("********Fun with FileStreams******\n");
            using (FileStream fStream = File.Open(@"d:\myMessage.dat",FileMode.Create))
            {
                //把字符串编码成字节数组
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);
                //把byte[]写入文件
                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                //重置流内部的位置
                fStream.Position = 0;
                //从文件中读取字节并显示出来
                textBox1.AppendText("Your message as an aray of bytes: \n");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    textBox1.AppendText(bytesFromFile[i].ToString());
                }
                textBox1.AppendText("\n");
                //显示解码后的字节符
                textBox1.AppendText("Decoded message: \n");
                textBox1.AppendText(Encoding.Default.GetString(bytesFromFile)+"\n");
            }
        }
        [Serializable]
        public class UserPrefs
        {
            public string WindowColor;
            public int FontSize;
        }
        private void SerializeTest()
        {
            UserPrefs userData = new UserPrefs();
            userData.WindowColor = "Yellow";
            userData.FontSize = 50;
            //BinaryFormatter 以二进制格式持久化状态数据
            BinaryFormatter binFormat = new BinaryFormatter();
            //现在将对象保存到一个本地文件中
            using(Stream fStream = new FileStream(@"D:\user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userData);
            }
            XmlSerializer xmlFormat = new XmlSerializer(typeof(UserPrefs));
            using (Stream fStream = new FileStream(@"D:\user.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, userData);
            }
        }

        private void btnRegex_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.AppendText("*******Fun with regex******\n");
            string testText = @"0735-2616282,
                (0735)-2612823";
            Regex testRegex = new Regex(@"(?<area>0\d{2,3})-\d{7,8}") ;
            Match telNumber = testRegex.Match(testText);
            if (telNumber.Success)
            {
                textBox1.AppendText(telNumber.Value+"\n");
            }
            int[] intArr = testRegex.GetGroupNumbers();
            foreach (var i in intArr)
            {
                textBox1.AppendText(string.Format("Groups num: {0}\n", i));
            }
            string[] stringArr = testRegex.GetGroupNames();
            foreach(string groupName in stringArr)
            {
                textBox1.AppendText(string.Format("Group name:{0}\n", groupName));
            }
            textBox1.AppendText(string.Format("Area: {0}\n", telNumber.Groups["area"]));

//零宽语言（或者称作：环视）
            //(exp) 匹配exp，并捕获文本到自动命令组里面
            Regex reg = new Regex(@"A(\w+)A");
            textBox1.AppendText(reg.Match("dsA123A").ToString()+"\n");
            textBox1.AppendText(reg.Match("dsA123A").Groups[1].Value+"\n");

            //(?<name>exp) 匹配exp，并捕获到名称为name的命令组里面，也可以写成(?'name'exp)
            Regex reg2 = new Regex(@"A(?<num>\w+)A");
            textBox1.AppendText(string.Format("(?<name>exp) 匹配exp: {0}\n",reg2.Match("dsA123A").Groups["num"].Value));

            //(?:(exp)匹配exp但不获取匹配结果
            Regex reg3 = new Regex(@"A(?:\w+A)");
            textBox1.AppendText(string.Format("(?:exp) 匹配EXP：{0} \n",reg3.Match("dsA123A"))); 

            //(?=exp) 匹配exp前面的位置  零宽正向预测先行断言
            Regex reg4 = new Regex(@"sing(?=ing)");
            textBox1.AppendText(string.Format("(?=exp) 匹配结果：{0} \n", reg4.Match("ksingkksingingkkk")));
            textBox1.AppendText(string.Format("(?=exp) 匹配结果在 ksingkksingingkkk的位置： {0} \n", reg4.Match("ksingkksingingkkk").Index));

            //(?<=exp) 匹配exp后面的位置， 零宽度正回顾后发断言
            Regex reg5 = new Regex(@"(?<=wo)man");
            textBox1.AppendText(string.Format("(?<=exp) 匹配结果： {0}\n", reg5.Match("hi man hi woman")));
            textBox1.AppendText(string.Format("(?<=exp) 匹配结果在 hi man hi woman 中的位置： {0} \n", reg5.Match("hi man hi woman").Index));

            Regex reg6 = new Regex(@"(?<数字分组>\d+)abc");
            Match m = reg6.Match("s123abcdefg");
            textBox1.AppendText(string.Format("Match: success: {0} value:{1} length:{2} index: {3} \n", m.Success, m.Value, m.Length, m.Index));
            GroupCollection mGroups = m.Groups;
            foreach  (Group g in mGroups)
            {
                textBox1.AppendText(string.Format("Group:  success: {0} value:{1} length:{2} index: {3} \n", g.Success, g.Value, g.Length, g.Index));
            }


        }

        private string testEncode(byte[] testByte)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < testByte.Length; i++)
            {
                builder.Append(testByte[i].ToString("x2"));
            }
            return builder.ToString();
        }
        private long getUnixTime(DateTime dt)
        {
            TimeSpan ts;
            ts = dt.ToUniversalTime() - new DateTime(1970, 1, 1,0,0,0);
            return (long)ts.TotalSeconds;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(test, null);
        }
        private void test(object state)
        {

            textBox1.Text = "";
            /*
            int test = 0/ 100;
            int test2 = 0% 100;
            textBox1.AppendText(string.Format("66/10: {0}\n", test));
            textBox1.AppendText(string.Format("66%10:{0}\n", test2));
            
            string test = "中";
            byte[] testByte = System.Text.Encoding.Default.GetBytes(test);
            textBox1.AppendText(string.Format("中 (Default)：{0} \n",testEncode(testByte)));
            testByte = System.Text.ASCIIEncoding.ASCII.GetBytes(test);
            textBox1.AppendText(string.Format("中 (ASCII)：{0}\n", testEncode(testByte)));
            testByte = System.Text.Encoding.Unicode.GetBytes(test);
            textBox1.AppendText(string.Format("中 (Unicode)：{0}\n", testEncode(testByte)));
            testByte = System.Text.Encoding.UTF8.GetBytes(test);
            textBox1.AppendText(string.Format("中 (UTF8)：{0}\n", testEncode(testByte)));
            */
            string test = dateTimePicker1.Value.ToShortDateString();
            DateTime stringToDate = DateTime.Parse(test);
            DateTime originDate = DateTime.Parse(test);
            Random ran = new Random();
            double rndM = ran.Next(0, 60);
            double rndH = ran.Next(9, 20);
            double rndS = ran.Next(0, 60);
            textBox1.AppendText(string.Format("H: {0}  M: {1}  S: {2} \n", rndH, rndM, rndS));
            stringToDate = stringToDate.AddDays(90);
            stringToDate = stringToDate.AddHours(rndH);
            stringToDate = stringToDate.AddMinutes(rndM);
            stringToDate = stringToDate.AddSeconds(rndS);
            //DateTime testDate = dateTimePicker1.Value.ToLocalTime();
            textBox1.AppendText(test + "\n");
            textBox1.AppendText(string.Format("测试时间：{0} :  Unix: {1} \n", stringToDate, getUnixTime(stringToDate)));

            DateTime dt = DateTime.Today;
            textBox1.AppendText(string.Format("测试时间：{0} :  Unix: {1} \n", dt.ToString(), getUnixTime(dt)));
            TimeSpan ts = dt - originDate;
            textBox1.AppendText(string.Format("两时间相差天数： {0} \n", ts.TotalDays));


            CancellationToken cancelToken = cancelTokenSource.Token;
            for (int i = 0; i < 100000; i++)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    textBox1.AppendText("取消测试\n");
                    break;
                }
                textBox1.AppendText(string.Format("当前打印：{0}\n", i));
                
            }
            textBox1.AppendText("测试结束\n");
        }

        private void btnCancelTest_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void btnSubstrcn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            //string testWords = "街头巷尾总是少不了那些时尚的潮人，她们的穿衣花样百出，今年夏季这些潮人们又是怎么穿搭的呢?有哪些时尚的穿搭可以让我们在这个将要结束的夏天里再美上一把呢?下面，小编就带领着各位亲们来看看超级时尚的穿衣搭配方法! 搭配1 小格子很显瘦哟~~格子吊带连衣裙 + 百搭T + 尖头单鞋，这样的搭配真是超漂亮减龄的，特别喜欢这款小格子连衣裙，适合和T一起搭，浅蓝色的格子连衣裙很清新不是吗 ? ";
            //string testWords = "大牌为什么被称为大牌，不是没有原因的。高贵的质感和舒适的感受是其它任何小作坊里出来的衣服都无法比的。就是这么霸道又任性在穿衣打扮的世界里横行，不由分说就强势来袭。别以为大牌总是一副高高在上遥不可及的样子，其实，它更多的是偏向于走低调奢华有内涵的路子。哪怕是亲和如邻家妹妹的类型，也能轻松hold住毫无压力，说到底，不过就是一个娃娃领的差距嘛。";
            string testWords = @"吴亦凡Burberry走秀，这在亚洲男演员中堪称史无前例,以往高冷的奢侈品牌也看到了“小鲜肉”的威力！关于吴亦凡是否走秀的疑云，也早已将Burberry推上媒体热搜榜，不管是对于品牌还是对于吴亦凡个人，“第一个吃螃蟹的人”都赢了。";
            textBox1.AppendText(string.Format("{0} \n 长度：{1}\n",testWords,testWords.Length));
            string testSubString = testWords.Substring(0, 100);
            textBox1.AppendText("\n");
            textBox1.AppendText(string.Format("截取100个字符：{0}\n", testSubString));
            char[] splitChars = {'。' ,'？','！','.','?','!'};
            string[] stringArr = testWords.Split(splitChars);
            textBox1.AppendText("\n");
            textBox1.AppendText("以下是将文章用 ？ 。！ 包括英文的 ? . ! 分割的字符组：\n");
            string description = "";
            string nextSentence = "";
            foreach (string item in stringArr)
            {
                //textBox1.AppendText(string.Format("{0}\n", item));
                string temp = description + item;
                if (temp.Length < 120)
                {
                    description = description + item;
                }
                else
                {
                    nextSentence = item;
                    break;
                }
            }
            //description+=testWords.Substring(description.Length+2, 1);
            int spliterIndex = 0;
            if (nextSentence!="")
            {
                spliterIndex = testWords.IndexOf(nextSentence) - 1;
            }
            else
            {
                spliterIndex = testWords.Length - 1;
            }
            description = description + testWords.Substring(spliterIndex, 1);
            textBox1.AppendText(string.Format("Spliter Index:{0}\n",spliterIndex));
            textBox1.AppendText(string.Format("Description：{0} \n", description));
        }

        #region 缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumb(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        //y = (originalImage.Height - oh) / 2;
                        y = 0;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;


            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        public static void GenThumbnail(System.Drawing.Image  imageFrom, string pathImageTo, int width, int height)
        {

            if (imageFrom == null)
            {
                return;
            }
            // 源图宽度及高度 
            int imageFromWidth = imageFrom.Width;
            int imageFromHeight = imageFrom.Height;
            // 生成的缩略图实际宽度及高度 
            int bitmapWidth = width;
            int bitmapHeight = height;
            // 生成的缩略图在上述"画布"上的位置 
            int X = 0;
            int Y = 0;
            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际尺寸及其在"画布"上的位置 
            if (bitmapHeight * imageFromWidth > bitmapWidth * imageFromHeight)
            {
                bitmapHeight = imageFromHeight * width / imageFromWidth;
                Y = (height - bitmapHeight) / 2;
            }
            else
            {
                bitmapWidth = imageFromWidth * height / imageFromHeight;
                X = (width - bitmapWidth) / 2;
            }
            // 创建画布 
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            // 用白色清空 
            g.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            //g.SmoothingMode = SmoothingMode.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;

            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
            g.DrawImage(imageFrom, new Rectangle(X, Y, bitmapWidth, bitmapHeight), new Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);
            try
            {
                //经测试 .jpg 格式缩略图大小与质量等最优 
                bmp.Save(pathImageTo, ImageFormat.Jpeg);
            }
            catch
            {
            }
            finally
            {
                //显示释放资源 

                bmp.Dispose();
                g.Dispose();
            }
        }
        private void btnMakeThumb_Click(object sender, EventArgs e)
        {
            //string imgPath = @"F:\lady11\src\0\1\00qnpuip.yvk.png";
            string imgTest1Path = @"F:\lady11\test1.jpg";
            string imgTest2Path = @"F:\lady11\test2.jpg";
            string imgTest3Path = @"F:\lady11\test3.jpg";
            string imgTest4Path = @"F:\lady11\test4.jpg";
            string imgTest5Path = @"F:\lady11\test5.jpg";

            MakeThumb(imgTest1Path, @"F:\lady11\thumb1.jpg", 158, 140, "Cut");
            MakeThumb(imgTest2Path, @"F:\lady11\thumb2.jpg", 158, 140, "Cut");
            MakeThumb(imgTest3Path, @"F:\lady11\thumb3.jpg", 158, 140, "Cut");
            MakeThumb(imgTest4Path, @"F:\lady11\thumb4.jpg", 158, 140, "Cut");
            MakeThumb(imgTest5Path, @"F:\lady11\thumb5.jpg", 158, 140, "Cut");

            /*
            Image testImage = Image.FromFile(imgPath);
            GenThumbnail(testImage, @"F:\lady11\testthumb.jpg", 300, 300);
            testImage = Image.FromFile(imgTest1Path);
            GenThumbnail(testImage, @"F:\lady11\thumb1.jpg", 300, 300);
            testImage = Image.FromFile(imgTest2Path);
            GenThumbnail(testImage, @"F:\lady11\thumb2.jpg", 300, 300);
            testImage = Image.FromFile(imgTest3Path);
            GenThumbnail(testImage, @"F:\lady11\thumb3.jpg", 300, 300);*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            string testFile = File.ReadAllText("test.txt");
            //textBox1.AppendText(testFile);
            // Regex regSplit = new Regex("<hr class=\"ke - pagebreak\" style=\"page -break-after:always; \" />");
            Regex regSplit = new Regex("<hr.*?class=[^>]*>");
            string[] output = regSplit.Split(testFile);

            foreach (var item in output)
            {
                textBox1.AppendText(item);
                textBox1.AppendText("-------------------------------------------\n");
            }
            */
            /*
            string testUrl = "http://www.lady11.com/getwximg.php?url=http://www.lady11.com/2";
            string testStr = GetHtml(testUrl);
            textBox1.AppendText(testStr+"\n");
            Serializer testSerializer = new Serializer();
            
            //ArrayList al = (ArrayList)testSerializer.Deserialize(testStr);
            textBox1.AppendText(testSerializer.Deserialize(testStr).ToString());
            */
            /*
            for (int i = 0; i < al.Count; i++)
            {
                Hashtable ht = (Hashtable)al[i];
                foreach (string item in ht)
                {
                    textBox1.AppendText(item+"\n");
                }
                //do something
            }
            */
            /*
            Regex regClear = new Regex(@"[\W_]+");
            string test = @"🔥【玛丽艳】彩妆系列，你应该还没见过这么好的彩妆吧！";
            string unclear = "《》（）？！。，、‘“”’•[]<>?!.,()'\" *= -|";
            MatchCollection MColl = regClear.Matches(test);
            foreach (Match item in MColl)
            {
                if (!unclear.Contains(item.Value))
                {
                    test = test.Replace(item.Value, "");
                }
            }*/
            /*
            string test = "<img src=\"http://wximg.yaoyaolady.com/x.jp\" /> <img  src=\"http://mmbiz.qpic.cn/mmbiz/ia0sPqcP14y9JHIrqzZ1eLzQC6Vpj5viaqzh6F2lomdaZGy0ZtdHRXVaKFA3mkmcpfxSL8OJ2Cv1AnsicfnP0icM7A/0?wx_fmt=jpeg\" />";
            Regex regWxpic = new Regex("mmbiz|qpic|qlogo");
            Regex regImg = new Regex("src=\"(?<imgsrc>[^\"]*?)\"");
            MatchCollection matches = regImg.Matches(test);
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                //textBox1.AppendText(string.Format("whole match:{0} matched src={1} \n", match.Value, groups["imgsrc"]));
                string imgSrc = groups["imgsrc"].Value;
                if (regWxpic.IsMatch(imgSrc))
                {
                    textBox1.AppendText(string.Format("unresolved src: {0}\n", match.Value));
                    string finalImgUrl = "http://wximg.yaoyaolady.com/getwximg.php?type=sharp&pass=cxmylove2552&url=" + imgSrc;
                    string finalDownloadUrl = GetHtml(finalImgUrl);
                    int count = 0;
                    while (finalDownloadUrl=="" && count <10)
                    {
                        finalDownloadUrl = GetHtml(finalImgUrl);
                        count++;
                        Thread.Sleep(500);
                    }
                    if (finalDownloadUrl!="")
                    {
                        test = test.Replace(imgSrc, finalDownloadUrl);
                    }
                }
            }
            
            
            string test = "<img src=\"http://wximg.xx.com/x.jpg\" /><img src=\"http://wximg.xx.com/x.gif\" /><img src=\"http://wximg.xx.com/x.png\" /> <img  src=\"http://mmbiz.qpic.cn/mmbiz/ia0sPqcP14y9JHIrqzZ1eLzQC6Vpj5viaqzh6F2lomdaZGy0ZtdHRXVaKFA3mkmcpfxSL8OJ2Cv1AnsicfnP0icM7A/0?wx_fmt=jpeg\" />";
            Regex regWxpic = new Regex("mmbiz|qpic|qlogo");
            Regex regFormat = new Regex("jpg|jpeg|png|bmp");
            Regex regImg = new Regex("src=\"(?<imgsrc>[^\"]*?)\"");
            MatchCollection matches = regImg.Matches(test);
            List<string> listAllImgs = new List<string>();
            List<string> listThumbImgs = new List<string>();
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                //textBox1.AppendText(string.Format("whole match:{0} matched src={1} \n", match.Value, groups["imgsrc"]));
                string imgSrc = groups["imgsrc"].Value;
                if (!regWxpic.IsMatch(imgSrc))
                {
                    listAllImgs.Add(imgSrc);
                    string imgExtenstion =Path.GetExtension(imgSrc).ToLower();
                    if (regFormat.IsMatch(imgExtenstion))
                    {
                        listThumbImgs.Add(imgSrc);
                    }
                }
            }
            string thumbUrl = "";
            int thumbCount = listThumbImgs.Count;
            if (thumbCount>0)
            {
                thumbUrl = listThumbImgs[0];
            }
            if (thumbCount>3 && thumbCount <6)
            {
                Random rnd = new Random();
                int id = rnd.Next(2, thumbCount - 2);
                thumbUrl = listThumbImgs[id];
            }
            if (thumbCount>6)
            {
                Random rnd = new Random();
                int id = rnd.Next(2,5);
                thumbUrl = listThumbImgs[id];
            }
            if (thumbUrl=="" && listAllImgs.Count>3)
            {
                Random rnd = new Random();
                int id = rnd.Next(2, listAllImgs.Count-2);
                thumbUrl = listAllImgs[id];
            }
            else if (listAllImgs.Count>0)
            {
                thumbUrl = listAllImgs[0];
            }
            
            textBox1.AppendText(thumbUrl);
            */
            List<string> imgs = new List<string>();
            imgs.Add("http://wximg.yaoyaolady.com/wximgs/2016/04/21/14/05351cdcb87dda3ae6ffeca172856b3d.jpeg");
            imgs.Add("http://wximg.yaoyaolady.com/wximgs/2016/04/21/14/9d4ea154e27830e0e1145f377e1242fa.jpeg");
            imgs.Add("http://wximg.yaoyaolady.com/wximgs/2016/04/21/14/9a9563dd06283aa76e1f2d996eface31.jpeg");
            //Image thumb = Image.FromFile(imgurl);
            /*
            List<long> listImgSize = new List<long>();
            foreach (string imgurl in imgs)
            {
                listImgSize.Add(GetRemoteHTTPFileSize(imgurl));
            }
            int maxIndex = 0;
            for (int i = 0; i < listImgSize.Count; i++)
            {
                if (listImgSize[maxIndex]<listImgSize[i])
                {
                    maxIndex = i;
                }
            }
            string thumbUrl = imgs[maxIndex];
            if (listImgSize[maxIndex]<20000)
            {
                listImgSize.Clear();
                maxIndex = 0;
                foreach (string imgurl in imgs)
                {
                    listImgSize.Add(GetRemoteHTTPFileSize(imgurl));
                }
                for (int i = 0; i < listImgSize.Count; i++)
                {
                    if (listImgSize[maxIndex] < listImgSize[i])
                    {
                        maxIndex = i;
                    }
                }
                thumbUrl = imgs[maxIndex];
            }
            textBox1.AppendText(imgs.ToString()+"\n");
            textBox1.AppendText(thumbUrl);
            */
            //Thread.Sleep(500);
            IntPtr test1 = (IntPtr)1;
            int test =  System.Runtime.InteropServices.Marshal.SizeOf(test1);
            textBox1.Text = test.ToString();
        }
        public string GetHtml(string strUrl)
        {

            WebRequest request = WebRequest.Create(strUrl);
            //request.Credentials = new System.Net.NetworkCredential( "用户名", "密码", "域" );  
            //request.Proxy = new WebProxy( "192.168.72.254:8080", true, new string[] { }, request.Credentials );  
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string str = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();
            response.Close();
            return str;

        }

        public  long GetRemoteHTTPFileSize(string sURL)
        {
            long size = 0L;
            try
            {
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(sURL);
                request.Method = "HEAD";

                System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                size = response.ContentLength;
                //size = System.Convert.ToInt64(response.Headers["Content-Length"]); 
                response.Close();
            }
            catch
            {
                size = 0L;
            }

            return size;
        }

        #region HTML转行成TEXT, （不替换HTML标签）
        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<div[^>]*?>.*?</div>",
            //@"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);",
            @"&(nbsp|#160);",
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
        #endregion

        private void btnXpathTest_Click(object sender, EventArgs e)
        {
            string testFile = File.ReadAllText("test.txt");
            //textBox1.AppendText(testFile);
            Regex regSplit = new Regex("<hr.*?class=[^>]*>");
            string[] output = regSplit.Split(testFile);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(testFile);
                string arcContent = doc.DocumentNode.InnerHtml;
                HtmlAgilityPack.HtmlNodeCollection imageNodes = doc.DocumentNode.SelectNodes("//div");
                for (int i = 0; i < imageNodes.Count-1; i++)
                {
                    HtmlAgilityPack.HtmlNode node = imageNodes[i];
                    string nodeContent =node.InnerHtml;
                    nodeContent = HtmlToTxt(nodeContent);
                    textBox1.AppendText(nodeContent + "\n");
                    textBox1.AppendText("-------------------\n");
                }
                HtmlAgilityPack.HtmlNode lastNode = imageNodes[imageNodes.Count-1];
                textBox1.AppendText(HtmlToTxt( lastNode.InnerHtml));

                /*foreach (HtmlAgilityPack.HtmlNode node in imageNodes)
                {
                    string nodeContent = node.OuterHtml;
                    nodeContent = HtmlToTxt(nodeContent);
                    textBox1.AppendText(nodeContent+"\n");
                    //textBox1.AppendText("-------------------\n");
                }
                */
                // textBox1.AppendText(testOutput);
            }
            catch (Exception)
            {

            }

            /*
            foreach (var item in output)
            {
                textBox1.AppendText(item);
                textBox1.AppendText("-------------------------------------------\n");
            }
            */
        }

        private void imageMagicTest(string sourcePath,string dstPath,int width,int height,string type)
        {
            /*
            ImageMagick.MagickImage objMagic = new MagickImage();
            objMagic.Read(sourcePath);
            objMagic.Quality = 100;
            objMagic.Resize(new MagickGeometry(new System.Drawing.Rectangle(0, 0, width, height)));
            objMagic.Thumbnail(new MagickGeometry(new System.Drawing.Rectangle(0, 0, width, height)));
            objMagic.Sharpen();
            //objMagic.AdaptiveSharpen();
            objMagic.Write(dstPath);
            */

        }

        private void ProcessImage(string sourcePath, string dstPath, int width, int height, string mode)
        {
            // FullPath is the new file's path.
            //ImageMagick.MagickImage img = new ImageMagick.MagickImage(sourcePath);
            GraphicsMagick.MagickImage img = new GraphicsMagick.MagickImage(sourcePath);

            String file_name = System.IO.Path.GetFileName(sourcePath);

            if (img.Height != height || img.Width != width)
            {
                int new_width = width;
                int new_height = height;
                GraphicsMagick.Gravity dstGravity = new GraphicsMagick.Gravity(); //设置目标截取的位置
                dstGravity = Gravity.Center;  //默认截取位置是从中间截取
                decimal result_ratio = (decimal)height / (decimal)width;   //目标
                decimal current_ratio = (decimal)img.Height / (decimal)img.Width;

                switch (mode)
                {
                    case "HW":      //指定高宽缩放（可能变形）
                        break;
                    case "W":       //指定宽，高按比例
                        new_height = img.Height * width / img.Width;
                        dstGravity = Gravity.North;
                        break;
                    case "H":       //指定高，宽按比例
                        new_width = img.Width * height / img.Height;
                        break;
                    case "Cut":         //指定高宽裁减（不变形）    
                        Boolean preserve_width = false;
                        if (current_ratio > result_ratio)
                        {
                            preserve_width = true;
                        }
                        if (preserve_width)
                        {
                            dstGravity = Gravity.North;
                            new_width = width;
                            new_height = (int)Math.Round((decimal)(current_ratio * new_width));
                        }
                        else
                        {
                            dstGravity = Gravity.Center;
                            new_height = height;
                            new_width = (int)Math.Round((decimal)(new_height / current_ratio));
                        }
                        break;
                    default:
                        break;
                }
                String newGeomStr = new_width.ToString() + "x" + new_height.ToString()+"!";
                GraphicsMagick.MagickGeometry intermediate_geo = new GraphicsMagick.MagickGeometry(newGeomStr);
                //img.Resize(intermediate_geo);
                
                img.Thumbnail(intermediate_geo);
                img.Crop(width,height,dstGravity);
            }
            
            img.Quality = 90;
            //img.FilterType = FilterType.Triangle;
            img.Sharpen();
            //img.AdaptiveSharpen();
            img.Write(dstPath+img.Quality.ToString() +Path.GetExtension(dstPath));
        }

        private void btnImageMagic_Click(object sender, EventArgs e)
        {
            string waterMarkFile = @"F:\lady11\yaoyaolady-watermark.png";
            string bigWatermarkFile = @"F:\lady11\yaoyaolady-watermark-big.png";
            string mediumWatermarkFile = @"F:\lady11\yaoyaolady-watermark-medium.png";
            string smallWatermarkFile = @"F:\lady11\yaoyaolady-watermark-small.png";
            string imgSrc1Path = @"F:\lady11\test1.jpg";
            string imgSrc2Path = @"F:\lady11\test2.jpg";
            string imgSrc3Path = @"F:\lady11\test3.jpg";
            string imgSrc4Path = @"F:\lady11\test4.jpg";
            string imgSrc5Path = @"F:\lady11\test5.jpg";
            string[] imgSrc = { @"F:\lady11\test1.jpg", @"F:\lady11\test2.jpg", @"F:\lady11\test3.jpg", @"F:\lady11\test4.jpg", @"F:\lady11\test5.jpg" };
            string imgDst1Path = @"F:\lady11\dst1.jpg";
            string imgDst2Path = @"F:\lady11\dst2.jpg";
            string imgDst3Path = @"F:\lady11\dst3.jpg";
            string imgDst4Path = @"F:\lady11\dst4.jpg";
            string imgDst5Path = @"F:\lady11\dst5.jpg";
            string[] dstDir = { "test1", "test2", "test3", "test4", "test5" };
            /*
            Stopwatch testMagic = new Stopwatch() ;
            testMagic.Start();
            ProcessImage(imgSrc1Path, @"F:\lady11\magic1.jpg", 158, 140, "Cut");
            ProcessImage(imgSrc2Path, @"F:\lady11\magic2.jpg", 158, 140, "Cut");
            ProcessImage(imgSrc3Path, @"F:\lady11\magic3.jpg", 158, 140, "Cut");
            ProcessImage(imgSrc4Path, @"F:\lady11\magic4.jpg", 158, 140, "Cut");
            ProcessImage(imgSrc5Path, @"F:\lady11\magic5.jpg", 158, 140, "Cut");
            testMagic.Stop();
            textBox1.AppendText(string.Format("使用image处理缩略图时间：{0}\n", testMagic.Elapsed.TotalMilliseconds));
            */
            
            for (int i = 0; i < 5; i++)
            {
                foreach (GraphicsMagick.CompositeOperator watermarkType in (GraphicsMagick.CompositeOperator[])Enum.GetValues(typeof(GraphicsMagick.CompositeOperator)))
                {
                    string typeName = watermarkType.ToString();
                    string dstFilename = @"F:\lady11\"+dstDir[i]+@"\" + typeName + ".jpg";
                    if (!Directory.Exists(Path.GetDirectoryName(dstFilename)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(dstFilename));
                    }
                    string tempWatermarkFile = waterMarkFile;
                    System.Drawing.Image tempSrcImg = System.Drawing.Image.FromFile(imgSrc[i]);
                    if (tempSrcImg.Width<=500)
                    {
                        tempWatermarkFile = smallWatermarkFile;
                    }
                    else if(tempSrcImg.Width<=700)
                    {
                        tempWatermarkFile = mediumWatermarkFile;
                    }
                    else
                    {
                        tempWatermarkFile = bigWatermarkFile;
                    }

                    using (GraphicsMagick.MagickImage watermark = new GraphicsMagick.MagickImage(tempWatermarkFile))
                    {
                        GraphicsMagick.MagickImage srcImg = new MagickImage(imgSrc[i]);
                        srcImg.Composite(watermark, Gravity.Southeast, watermarkType);
                        srcImg.Write(dstFilename);
                    }
                }
            }
            
            textBox1.AppendText("处理图片结束\n");
            /*
            ImageMagick.MagickImage img1 = new MagickImage(imgSrc1Path);
            ImageMagick.MagickImage img2 = new MagickImage(imgSrc2Path);
            ImageMagick.MagickImage img3 = new MagickImage(imgSrc3Path);
            ImageMagick.MagickImage img4 = new MagickImage(imgSrc4Path);
            ImageMagick.MagickImage img5 = new MagickImage(imgSrc5Path);

            using (MagickImage watermark = new MagickImage(waterMarkFile))
            {
                img1.Composite(watermark, Gravity.Southeast);
                img1.Write(imgDst1Path);

                img2.Composite(watermark, Gravity.South,ImageMagick.CompositeOperator.Alpha);
                img2.Write(imgDst2Path);

                img3.Composite(watermark, Gravity.Southwest, ImageMagick.CompositeOperator.Atop);
                img3.Write(imgDst3Path);

                img4.Composite(watermark, Gravity.Northeast, ImageMagick.CompositeOperator.Blend);
                img4.Write(imgDst4Path);

                img5.Composite(watermark, Gravity.Northwest,ImageMagick.CompositeOperator.Blur);
                img5.Write(imgDst5Path);
            }
            */

        }

        private void btnAforge_Click(object sender, EventArgs e)
        {
            string imgTest1Path = @"F:\lady11\test1.jpg";
            string imgTest2Path = @"F:\lady11\test2.jpg";
            string imgTest3Path = @"F:\lady11\test3.jpg";
            string imgTest4Path = @"F:\lady11\test4.jpg";
            string imgTest5Path = @"F:\lady11\test5.jpg";
            Stopwatch magicWatch = new Stopwatch();
            //imageMagic
            magicWatch.Start();
            //ImageMagick.MagickImage testMagic = new MagickImage(imgTest1Path);
            GraphicsMagick.MagickImage testMagic = new MagickImage(imgTest1Path);

            testMagic.Sharpen();
            testMagic.Write(@"F:\lady11\test1-magic-sharpen.jpg");
            magicWatch.Stop();
            textBox1.AppendText(string.Format("使用imageMagic处理图片锐化时间：{0}\n", magicWatch.Elapsed.TotalMilliseconds));

            //aforge
            Stopwatch aforgeWatch = new Stopwatch();
            aforgeWatch.Start();
            Bitmap testImg = AForge.Imaging.Image.FromFile(imgTest1Path);
            AForge.Imaging.Filters.Sharpen filter = new AForge.Imaging.Filters.Sharpen();
            filter.Apply(testImg);
            Bitmap sharpTest1 = filter.Apply(testImg);
            sharpTest1.Save(@"F:\lady11\test1-aforge-sharpen.jpg");
            aforgeWatch.Stop();
            textBox1.AppendText(string.Format("使用aforge处理图片锐化时间：{0}\n", aforgeWatch.Elapsed.TotalMilliseconds));

            AForge.Imaging.Filters.Grayscale filterG = new AForge.Imaging.Filters.Grayscale(0.2125, 0.7154, 0.0721);
            filterG.Apply(testImg);
            Bitmap grayscaleTest1 = filterG.Apply(testImg);
            grayscaleTest1.Save(@"F:\lady11\test1-grayscale-.jpg");

        }

        #region HTML转行成TEXT, （不替换HTML标签）
        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string ClearStyle(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>[\s\S]+?</script>",
            @"</?a[^>]*>",
            "style=\"[^\"]*?\"",
            "class=\"[^\"]*\"",
            @"</?strong[^>]*>",
            @"<style[^>]*?>[\s\S]+?</style>",
            "onclick=\"[^\"]*?\"",
            "alt=\"[^\"]*?\"",
            "onload=\"[^\"]*?\"",
            @"<p[^>]+>",
            @"<div[^>]+>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);",
            @"&(nbsp|#160);",
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };
            string[] aryReplace ={
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            @"<p>",
            @"<div>",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, aryReplace[i]);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");
            strOutput= strOutput.Replace("<div>", "");
            strOutput= strOutput.Replace("</div>", "");
            strOutput = strOutput.Replace("http://", "http://yypicwx.zaichenzhou.net/pic/");
            strOutput = strOutput.Replace("</p>", "</p> <br />");

            return strOutput;
        }
        #endregion
        private void btnClearHtml_Click(object sender, EventArgs e)
        {
            string originTextFile = "2016-6-15.txt";
            string dstTextFile = "2016-6-15-dst.txt";
            string originText = File.ReadAllText(originTextFile,Encoding.UTF8);
            string dstText = ClearStyle(originText);
            File.WriteAllText(dstTextFile, dstText,Encoding.UTF8);
            MessageBox.Show("成功清除格式！清除后内容保存在:" + dstTextFile);

        }
    }

}
