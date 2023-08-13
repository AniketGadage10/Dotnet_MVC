using BOL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace BLL
{
    public class Userservice
    {
        public static string s =@"server=localhost;port=3306;user=root;password=root123;database=anu";
        
        public static int insertuser(User U)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = s;
            try
            {
                con.Open();
                string query = "insert into User(name,age,email,password,hobies,dob) values('" + U.name + "','" + U.age + "','" + U.email + "','" + U.password + "','" + U.hobies + "','" + U.dob.ToString("yyyy-MM-dd") + "')";
                MySqlCommand m=new MySqlCommand();    
                m.Connection= con;
                m.CommandText= query;
                m.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            { con.Close(); }
            return 1;
        }
    
        public static User Getbyid(int id)
        {
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                string str = "select * from User where id=" + id;

                MySqlCommand cmd = new MySqlCommand(str,m);
                MySqlDataReader reader= cmd.ExecuteReader();
                if(reader.Read())
                {
                    int eid = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    int age = int.Parse(reader["age"].ToString());
                    string email1 = reader["email"].ToString();
                    string password1 = reader["password"].ToString();
                    string hobies = reader["hobies"].ToString();
                    DateOnly d = DateOnly.FromDateTime(DateTime.Parse(reader["dob"].ToString()));
                    User u = new User(eid, name, age, email1, password1, hobies, d);
                    return u;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);   
            }finally { m.Close(); }
            return null;
        }

        public static List<User> Getbylist()
        {
            List<BOL.User>  list = new List<BOL.User>();
            
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                string str = "select * from User ";

                MySqlCommand cmd = new MySqlCommand(str, m);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int eid = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    int age = int.Parse(reader["age"].ToString());
                    string email1 = reader["email"].ToString();
                    string password1 = reader["password"].ToString();
                    string hobies = reader["hobies"].ToString();
                    DateOnly d = DateOnly.FromDateTime(DateTime.Parse(reader["dob"].ToString()));
                    User u = new User(eid, name, age, email1, password1, hobies, d);
                    list.Add(u);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally { m.Close(); }
            return list;
        }

        public static User validate(String email,String password)
        {
            MySqlConnection con=new MySqlConnection(s);
            try
            {
                con.Open();
                String str = "select * from user where email='" + email + "'and password='" + password + "'";
                MySqlCommand m=new MySqlCommand(str,con);
                MySqlDataReader r=m.ExecuteReader();
                if(r.Read())
                {
                    int id = int.Parse(r["id"].ToString());
                    string name = r["name"].ToString();
                    int age = int.Parse(r["age"].ToString());
                    string email1 = r["email"].ToString();
                    string password1 = r["password"].ToString();
                    string hobies = r["hobies"].ToString();
                    DateOnly d = DateOnly.FromDateTime(DateTime.Parse(r["dob"].ToString()));
                    User u=new User(id,name,age,email1,password1,hobies,d);
                    return u;
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public static int deletebyid(int id)
        {
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String str = "delete from user where id='" + id + "'";
                MySqlCommand M = new MySqlCommand(str, m);
                M.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally { m.Close(); }
         
        }
        public static int update(User u)
        {
            MySqlConnection m = new MySqlConnection(s);
            try
            {
                m.Open();
                String str="update user set name='"+u.name+"',age='"+u.age+"',email='"+u.email+"',password='"+u.password+"',hobies='"+u.hobies+"',dob='"+u.dob.ToString("yyyy-MM-dd")+"'where id='"+u.id+"'";
                MySqlCommand M = new MySqlCommand(str, m);
                M.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally { m.Close(); }
            return 1;
        }
    }
}