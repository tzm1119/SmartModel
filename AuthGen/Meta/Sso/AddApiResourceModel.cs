﻿using SmartModel;
using static AuthGen.MASAAuthTypeNameConst;
using static AuthGen.MASAAuthModuleNameConst;
using static AuthGen.MASAAuthEnumTypeNameConst;
using static SmartModel.PropertyNameConst;
using static SmartModel.PropertyDef;

namespace AuthGen
{


    public class AddApiResourceModel : MetaModelDef
    {
        public AddApiResourceModel()
        {
            SetName(AddApiResource)
                 .SetModuleName(Sso)
                .AddProperty(Bool(Enabled,true))
                .AddProperty(String_Name())
                .AddProperty(String(DisplayName))
                .AddProperty(String_Description())
                .AddProperty(String(AllowedAccessTokenSigningAlgorithms))
                .AddProperty(Bool(ShowInDiscoveryDocument))
                .AddProperty(DateTime(LastAccessed,true))
                .AddProperty(Bool(NonEditable))
                .AddProperty(List(_int,ApiScopes))
                .AddProperty(List(_int, UserClaims))
                .AddProperty(Dictionary_String_String_Properties())
                .AddProperty(List(_string, Secrets))
            ;
        }
    }
}