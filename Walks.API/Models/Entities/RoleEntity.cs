namespace Walks.API.Models.Entities;

public class RoleEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    // Navigation property
    public List<UserRoleEntity> UserRoles { get; set; } = new();
}