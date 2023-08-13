namespace BOL
{
    public enum Hobies
    {
        MUSIC,DANCING,GAMING,TEACHING
    }
    public class User
    {
        public int ? id { get; set; }
        public string ? name { get; set; }
        public int ? age { get; set; }
        public string ?  email { get; set; }
        public string ? password { get; set; }
        public Hobies hobies { get; set; }    
        public DateOnly dob { get; set; }

        public User() { }

        public User(string name,int age,String email,string password,String hobies,DateOnly date)
        {
            this.name= name;
            this.age= age;  
            this.email= email;
            this.password= password;
            this.hobies=Enum.Parse<Hobies>(hobies);
            this.dob= date;   
        }
        public User(int id,string name, int age, String email, string password, String hobies, DateOnly date)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.email = email;
            this.password = password;
            this.hobies = Enum.Parse<Hobies>(hobies);
            this.dob = date;
        }
        public override string ToString()
        {
            return " UserId :- " + id + " Name:- " + name + " Age:- " + age +
                " Email :-" + email + " Password :- " + password + " Hobbies :-"
                + this.hobies + " Birth_Date:- " + dob;
        }

    }
}