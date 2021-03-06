﻿using BSharp.Controllers.Misc;
using BSharp.Services.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BSharp.Controllers.DTO
{
    // Note: The permissions is a semi-weak entity, meaning it does not have its own screen or API
    // Permissions are always retrieved and saved as a child collection of some other strong entity
    // I call it "semi"- weak because it comes associated with more than one entity, therefore to stress
    // its weakness and for type-safety, we have two different DTOs

    public class PermissionForSave : DtoForSaveKeyBase<int?>
    {
        [Required(ErrorMessage = nameof(RequiredAttribute))]
        [StringLength(255, ErrorMessage = nameof(StringLengthAttribute))]
        [Display(Name = "Permission_View")]
        public string ViewId { get; set; }

        [Display(Name = "Permission_Role")]
        public int? RoleId { get; set; }

        [ChoiceList(new object[] 
            { Constants.Read, Constants.Update, Constants.Create, Constants.ReadCreate, Constants.Sign },  new string[] {
            "Permission_Read", "Permission_Update", "Permission_Create", "Permission_ReadAndCreate", "Permission_Sign" })]
        [Required(ErrorMessage = nameof(RequiredAttribute))]
        [StringLength(255, ErrorMessage = nameof(StringLengthAttribute))]
        [Display(Name = "Permission_Level")]
        public string Level { get; set; }

        [StringLength(1024, ErrorMessage = nameof(StringLengthAttribute))]
        [Display(Name = "Permission_Criteria")]
        public string Criteria { get; set; }

        [StringLength(255, ErrorMessage = nameof(StringLengthAttribute))]
        [Display(Name = "Memo")]
        public string Memo { get; set; }
    }

    public class Permission : PermissionForSave, IAuditedDto
    {
        [Display(Name = "CreatedAt")]
        public DateTimeOffset? CreatedAt { get; set; }

        [Display(Name = "CreatedBy")]
        public int? CreatedById { get; set; }

        [Display(Name = "ModifiedAt")]
        public DateTimeOffset? ModifiedAt { get; set; }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedById { get; set; }
    }

    // The two DTOs below carry permission information to the client so
    // the client can adjust the UI accordingly, the string key in the dictionary
    // represents the ViewId, its mere presence indicates that the user has read access
    // and the 3 boolean values indicate whether the user can create, update or sign
    // the associated view id
    public class PermissionsForClient : Dictionary<string, ViewPermissionsForClient>
    {
    }

    public class ViewPermissionsForClient
    {
        // The mere presence of this ViewPermission means that 
        // the user has read access over the associated viewId

        public bool? Read { get; set; }
        public bool? Create { get; set; }
        public bool? Update { get; set; }
        public bool? Sign { get; set; }
    }
}
