// Tạo builder để chuẩn bị cấu hình ứng dụng.
// Mặc định nạp cấu hình từ appsettings.json,
// Đồng thời chuẩn bị logging, dịch vụ và web server.

using Foundation.Api.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký các dịch vụ cần thiết để sử dụng controller.
builder.Services.AddControllers();

// Quy định cách biểu diễn kiểu dữ liệu số trong OpenAPI. - Áp dụng khi swagger không nhận được tham số int
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.NumberHandling =
        JsonNumberHandling.Strict;  
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Đăng ký dịch vụ tạo tài liệu mô tả API theo chuẩn OpenAPI.
builder.Services.AddOpenApi();

// Đăng ký DI các service trong ứng dụng.
builder.Services.AddSingleton<SampleItemService>();

// Tạo ứng dụng từ các dịch vụ và cấu hình đã chuẩn bị.
var app = builder.Build();

// Chỉ cung cấp tài liệu OpenAPI và Swagger UI trong môi trường Development.
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Tạo endpoint phục vụ tài liệu OpenAPI:
    // /openapi/v1.json
    app.MapOpenApi();

    // Bật giao diện Swagger UI tại /swagger.
    // Giao diện đọc tài liệu từ endpoint OpenAPI ở trên.
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/openapi/v1.json",
            "Foundation.Api v1");
    });
}

// Chuyển request HTTP sang HTTPS khi xác định được cổng HTTPS.
app.UseHttpsRedirection();

// Thêm bước kiểm tra quyền truy cập theo các quy tắc authorization.
app.UseAuthorization();

// Ánh xạ các action trong controller thành endpoint nhận request.
app.MapControllers();

// Khởi động web server và giữ ứng dụng chạy để nhận request.
app.Run();
