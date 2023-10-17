namespace LoginApi
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Userid { get; set; }
        public  Password Password 
        { 
            get { return Password; } 
            set 
            {
                //verefiy user 
                //check password
                Password = value;
            } 
        }

       
    }
}
