﻿namespace AuthGen
{
    public class ClientAuthenticationModel : MetaModelDef
    {
        public ClientAuthenticationModel()
        {
            SetName(ClientAuthentication)
                .SetModuleName(Sso)
                .SetDoNotGenDomainModel()
                .AddProperty(Int(Id)
                    .ExistIn(Dto))
                  .AddProperty(String(RedirectUri)
                    .ExistIn(Dto))
                  .AddProperty(ListString(RedirectUris)
                    .ExistIn(Dto))
              .AddProperty(String(PostLogoutRedirectUri)
                    .ExistIn(Dto))
                .AddProperty(ListString(PostLogoutRedirectUris)
                    .ExistIn(Dto))
                   .AddProperty(String(FrontChannelLogoutUri)
                    .ExistIn(Dto))
                  .AddProperty(Bool(FrontChannelLogoutSessionRequired)
                    .ExistIn(Dto))
                   .AddProperty(String(BackChannelLogoutUri)
                    .ExistIn(Dto))
                    .AddProperty(Bool(BackChannelLogoutSessionRequired)
                    .ExistIn(Dto))
                    .AddProperty(Bool(EnableLocalLogin)
                    .ExistIn(Dto))
                    .AddProperty(String(IdentityProviderRestriction)
                    .ExistIn(Dto))
                     .AddProperty(ListString(IdentityProviderRestrictions)
                    .ExistIn(Dto))
                     .AddProperty(Int(UserSsoLifetime)
                    .ExistIn(Dto))
                ;
        }
    }
}
