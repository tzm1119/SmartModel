using SmartModel;
using AuthGen;

Config.ContractsDir = @"D:\Devops\MASA.Auth\src\Contracts\Masa.Auth.Contracts.Admin\Gen";
Config.ServicesDir = @"D:\Devops\MASA.Auth\src\Services\Masa.Auth.Service.Admin\Gen";


List<GenBase> genList = new()
{
    // 后端
    new AggregateGen(),
    new DtoGen(),
    new RepositoryInterfaceGen(),
    new EntityTypeConfigurationGen(),
    new RepositoryImplGen(),
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
    new PermissionModel(),
    new PermissionRelationModel(),
    new RoleModel(),
    new RolePermissionModel(),
    new RoleRelationModel(),
    new SubjectPermissionRelationModel(),
    // Projects
    new AppNavigationTagModel(),
    // Sso
    new CustomLoginModel(),
    new CustomLoginThirdPartyIdpModel(),
    new RegisterFieldModel(),

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


    // Infrastructure
    new ClientModel_Model(),
  



};

foreach (var gen in genList)
{
    // 设置元数据集合
    gen.SetModelList(models);
    // 生成代码
    gen.GenCode();
}