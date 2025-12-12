// Import Namespace
using BackEnd.AccessData;
using BackEnd.Models;
using BackEnd.Controllers;

// Setup Builder
var builder = WebApplication.CreateBuilder(args);

// aktifkan controller
builder.Services.AddControllers();

// load konfigurasi database dari .env
builder.Services.AddSingleton(_ => DatabaseConfig.FromEnvironment());


builder.Services.AddScoped<SqlConnectionFactory>();
builder.Services.AddScoped<DataErrorHandler>();
builder.Services.AddScoped<DataUserCrud>();
builder.Services.AddScoped<DataUserList>();
// builder.Services.AddScoped<DataAdminCrud>();
// builder.Services.AddScoped<DataAdminList>();
// builder.Services.AddScoped<DataRoomTypeCrud>();
// builder.Services.AddScoped<DataRoomTypeList>();
// builder.Services.AddScoped<DataFacilityCrud>();
// builder.Services.AddScoped<DataFacilityList>();
// builder.Services.AddScoped<DataRoomPackageCrud>();
// builder.Services.AddScoped<DataRoomPackageList>();
// builder.Services.AddScoped<DataInsuranceCrud>();
// builder.Services.AddScoped<DataInsuranceList>();
// builder.Services.AddScoped<DataPolicyCrud>();
// builder.Services.AddScoped<DataPolicyList>();
// builder.Services.AddScoped<DataBookingPackageHistoryCrud>();
// builder.Services.AddScoped<DataBookingPackageHistoryList>();
// builder.Services.AddScoped<DataBookingPaymentCrud>();
// builder.Services.AddScoped<DataBookingPaymentList>();
// builder.Services.AddScoped<DataBookingGuestCrud>();
// builder.Services.AddScoped<DataBookingGuestList>();
// builder.Services.AddScoped<DataBookingCrud>();
// builder.Services.AddScoped<DataBookingList>();
// builder.Services.AddScoped<DataBookingDetailCrud>();
// builder.Services.AddScoped<DataBookingDetailList>();


builder.Services.AddEndpointsApiExplorer();


builder.Services.AddEndpointsApiExplorer();


// Controller Registration
builder.Services.AddControllers()
    .AddApplicationPart(typeof(UserCrudController).Assembly)
    .AddApplicationPart(typeof(UserListController).Assembly)
    // .AddApplicationPart(typeof(AdminCrudController).Assembly)
    // .AddApplicationPart(typeof(AdminListController).Assembly)
    // .AddApplicationPart(typeof(RoomTypeCrudController).Assembly)
    // .AddApplicationPart(typeof(RoomTypeListController).Assembly)
    // .AddApplicationPart(typeof(FacilityCrudController).Assembly)
    // .AddApplicationPart(typeof(FacilityListController).Assembly)
    // .AddApplicationPart(typeof(RoomPackageCrudController).Assembly)
    // .AddApplicationPart(typeof(RoomPackageListController).Assembly)
    // .AddApplicationPart(typeof(InsuranceCrudController).Assembly)
    // .AddApplicationPart(typeof(InsuranceListController).Assembly)
    // .AddApplicationPart(typeof(PolicyCrudController).Assembly)
    // .AddApplicationPart(typeof(PolicyListController).Assembly)
    // .AddApplicationPart(typeof(BookingPackageHistoryCrudController).Assembly)
    // .AddApplicationPart(typeof(BookingPackageHistoryListController).Assembly)
    // .AddApplicationPart(typeof(BookingPaymentCrudController).Assembly)
    // .AddApplicationPart(typeof(BookingPaymentListController).Assembly)
    // .AddApplicationPart(typeof(BookingGuestCrudController).Assembly)
    // .AddApplicationPart(typeof(BookingGuestListController).Assembly)
    // .AddApplicationPart(typeof(BookingCrudController).Assembly)
    // .AddApplicationPart(typeof(BookingListController).Assembly)
    // .AddApplicationPart(typeof(BookingDetailCrudController).Assembly)
    // .AddApplicationPart(typeof(BookingDetailListController).Assembly)
    ;


var app = builder.Build();
app.MapGet("/", () => Results.Ok(new { status = "ok" }));
app.MapControllers();
app.Run();
