using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CopyNotionApi3.Entities;

public class UserRefreshTokens
{
	[Key]
    [JsonIgnore]
	public int Id { get; set; }
	[Required]
	public string Email { get; set; }
	[Required]
	public string RefreshToken { get; set; }

	[JsonIgnore]
	public bool IsActive { get; set; } = true;
}
