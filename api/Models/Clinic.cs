using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models;

[Table("clinic")]
public class Clinic
{
    public int? id { get; set; }
    public string? name { get; set; }
}
