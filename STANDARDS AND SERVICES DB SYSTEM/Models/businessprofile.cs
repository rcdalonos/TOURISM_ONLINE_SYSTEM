using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STANDARDS_AND_SERVICES_DB_SYSTEM.Models;

[Table("businessprofile")]
public partial class businessprofile
{
    [Key]
    public int id { get; set; }

    [StringLength(150)]
    public string? businessname { get; set; }

    [StringLength(150)]
    public string? businessaddress { get; set; }

    [StringLength(150)]
    public string? telephoneno { get; set; }

    [StringLength(150)]
    public string? mobileno { get; set; }

    [StringLength(150)]
    public string? emailaddress { get; set; }

    [StringLength(150)]
    public string? businessowner { get; set; }

    [StringLength(150)]
    public string? owneraddress { get; set; }

    public int? typeid { get; set; }

    public int? classificationid { get; set; }
}
