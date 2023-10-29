namespace ConsoleApp1.EF_Crud_joins
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // add
            //AddEmployee("salil", 50000,2);
            //AddEmployee("achal", 40000,1);
            //AddEmployee("koi dost nhi", 10,4);


            // boss--------------->>>>>>
            //AddBoss("salil", "Senior Manager", "10");
            //AddBoss("achal", "Manager", "20");
            //AddBoss("dugu", "Senior Manager", "30");
            //AddBoss("dugudu", "employee", "7");


            // Joins
            JoinEmployeeAndBoss();
        }

        public static void JoinEmployeeAndBoss()
        {
            using(MyDbContext context = new MyDbContext())
            {
                var EmployeeTable = context.Employeess;
                var BossTable = context.Bossess;

                var qs = from emp in EmployeeTable
                         join boss in BossTable 
                         on emp.Boss_id equals boss.Boss_id
                       //  where emp.Id == 2
                  
                         select new
                         {
                             EmpName = emp.FullName,
                             BossName = boss.Boss_name
                         };

                foreach (var item in qs)
                {
                    Console.WriteLine($"{item.EmpName} : {item.BossName}");
                }
            }
        }
        public static void AddEmployee(string _name, int _salary,int _bossid)
        {
            EmployeeModel newEmp = new EmployeeModel
            { FullName = _name, SalaryInRS = _salary , Boss_id = _bossid};

            using (MyDbContext context = new MyDbContext())
            {
                var EmployeeTable = context.Employeess;
                EmployeeTable.Add(newEmp);
                context.SaveChanges();
            }
        }

        public static void AddBoss(string _name, string _post, string _experience)
        {
            Boss NewBoss = new Boss()
            {
                Boss_name = _name,
                Boss_Post = _post,
                Boss_experience = _experience
            };

            using (MyDbContext context = new MyDbContext())
            {
                var BossTable = context.Bossess;
                BossTable.Add(NewBoss);
                context.SaveChanges();
            }
        }
    }
}