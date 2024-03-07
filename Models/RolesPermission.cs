namespace contasoft_api.Models
{
    public class RolesPermission
    {
        public int Id { get; set; }
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public virtual Roles? Role { get; set; }
        public virtual Permissions? Permission { get; set; }
    }
}
