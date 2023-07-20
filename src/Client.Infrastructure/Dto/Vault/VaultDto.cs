using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.BlazorWebAssembly.Client.Infrastructure.Dto.Vault;
public class VaultDto
{
  


    public string Id { get; set; }
    public string UserName { get; set; }
    public string ProfilePictureDataUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public bool IsOnline { get; set; }
    public DateTime CreatedDate { get; set; }
}
