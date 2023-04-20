namespace WebApi.Models;

public class User
{
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string WebSite { get; set; }
    public Company  Company { get; set; }
}

public class Company
{
    public string Name { get; set; }
    public string CatchPhrase { get; set; }
    public string Bs { get; set; }
}
