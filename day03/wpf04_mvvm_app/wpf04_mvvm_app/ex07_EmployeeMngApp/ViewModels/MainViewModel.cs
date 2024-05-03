using Caliburn.Micro;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace ex07_EmployeeMngApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        // 멤버변수 
        private int id;
        private string empName;
        private decimal salary;
        private string deptName;
        private string addr; 

        // 속성
        public int Id { get { return id; } set => id = value; }
        public string EmpName { get { return empName; } set => empName = value; }
        public decimal Salary { get { return salary; } set => salary = value; }
        public string DeptName { get { return deptName; } set => deptName = value; }
        public string Addr { get { return addr; } set => addr = value; }


        public MainViewModel()
        {
            DisplayName = "직원관리시스템";
        }


        /// <summary>
        /// 칼리번이 xaml의 버튼 x:name과 동일한 이름의 메서드로 매핑 
        /// </summary>
        public void SaveEmployee()
        {
            using(SqlConnection conn = new SqlConnection(Helpers.Common.CONNSTRING))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = Models.Employees.INSERT_QUERY;

                SqlParameter prmEmpName = new SqlParameter("@EmpName", EmpName);
                cmd.Parameters.Add(prmEmpName);
                SqlParameter prmSalary = new SqlParameter("@Salary", Salary); 
                cmd.Parameters.Add(prmSalary);
                SqlParameter prmDeptName = new SqlParameter("@DeptName", DeptName);
                cmd.Parameters.Add(prmDeptName);
                SqlParameter prmAddr = new SqlParameter("@Addr", Addr);
                cmd.Parameters.Add(prmAddr);

                var result = cmd.ExecuteNonQuery();

                if(result > 0)
                {
                    MessageBox.Show("저장성공(❁´◡`❁)");
                }
                else
                {
                    MessageBox.Show("저장실패ᕦ(ò_óˇ)ᕤ");
                }
            }
        }
    }
}
