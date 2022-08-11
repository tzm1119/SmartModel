using SmartModel;
using AuthGen;

Config.ContractsDir = @"D:\Devops\MASA.Auth\src\Contracts\Masa.Auth.Contracts.Admin\Gen";
Config.ServicesDir = @"D:\Devops\MASA.Auth\src\Services\Masa.Auth.Service.Admin\Gen";
Config.CallerDir = @"D:\Devops\MASA.Auth\src\ApiGateways\Masa.Auth.ApiGateways.Caller\Gen";

ClearGen();

List<GenBase> genList = new()
{
    // 后端
    new AggregateGen(),
    new DtoGen(),
    new RepositoryInterfaceGen(),
    new EntityTypeConfigurationGen(),
    new RepositoryImplGen(),
    new CommandGen(),
    new QueryGen(),
    new CallerGen(),
    new RestServiceGen(),
    new CommandHandlerGen(),
    new DomainEvnetGen(),
    new DomainServiceGen(),
};

List<MetaModelDef> models = new()
{
    // Logs
    new OperationLogModel(),
    // Organizations
    new DepartmentModel(),
    new DepartmentStaffModel(),
    // Permissions
    new PositionModel(),
    new AppPermissionModel(),
    new MenuModel(),
    new MenuPermissionModel(),

    new PermissionModel(),
    new PermissionRelationModel(),
    new RoleModel(),
    new RoleOwnerModel(),
    new RolePermissionModel(),
    new RoleRelationModel(),
    new SubjectPermissionRelationModel(),
    // Projects
    new AppModel(),
    new AppNavigationTagModel(),
    new PermissionNavModel(),
    new ProjectModel(),

    // Oss
    new DefaultImagesModel(),
    new SecurityTokenModel(),

    // Sso
    new CustomLoginModel(),
    new CustomLoginThirdPartyIdpModel(),
    new RegisterFieldModel(),
    new ApiResourceModel(),
    new ApiScopeModel(),
    new UserClaimModel(),
    new IdentityResourceModel(),
    new ClientModel(),
    new ClientClaimModel(),
    new ClientSecretModel(),
    new ClientPropertyModel(),
    new ClientBasicModel(),
    new ClientAuthenticationModel(),
    new ClientConsentModel(),
    new ClientCredentialModel(),
    new ClientDeviceFlowModel(),
    new ClientScopesModel(),
    new ClientTokenModel(),
    new ClientTypeDetailModel(),


    // Subjects
    new AddressValueModel(),
    new AvatarValueModel(),
    new IdentityProviderModel(),
    new LdapIdpModel(),
    new StaffModel(),
    new TeamModel(),
    new TeamPermissionModel(),
    new TeamRoleModel(),
    new TeamStaffModel(),
    new ThirdPartyIdpModel(),
    new ThirdPartyUserModel(),
    new UserModel(),
    new UserPermissionModel(),
    new UserRoleModel(),
    new UserSystemBusinessDataModel(),
    new StaffPasswordModel(),
    new TeamPersonnelModel(),
    new TeamBasicInfoModel(),
    new TeamTypeModel(),
    new UserAuthorizationModel(),


    // Infrastructure
    //new ClientModel_Model(),
  



};

foreach (var gen in genList)
{
    // 设置元数据集合
    gen.SetModelList(models);
    // 生成代码
    gen.GenCode();
}

/// <summary>
///  删除所有生成代码
/// </summary>
void ClearGen()
{
    var paths = new string[]
    {
        Config.ContractsDir,
        Config.ServicesDir,
        Config.CallerDir,
    };
    foreach (var item in paths)
    {
        DeleteDir(item);
    }
}

void DeleteDir(string path)
{
    if (Directory.Exists(path))
    {
        Directory.Delete(path,true);
    }
   
}