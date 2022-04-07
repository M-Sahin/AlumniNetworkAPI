namespace AlumniNetworkAPI.Models.Domain
{
    public class GroupUser
    {
        public int Id { get; set; }
       public int Groupsgroup_id { get; set; }
       public Group group { get; set; }

       public int UseruserId { get; set; }
       public User user { get; set; }

    }
}
