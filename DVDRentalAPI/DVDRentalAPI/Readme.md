To know the IP Address of the container

docker inspect -f '{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}' container_name_or_id


Execute the commands in order to perform DB first approach and add models to your EntityFrameworkCore Application

1. dotnet add package Microsoft.EntityFrameworkCore.SqlServer
2. dotnet add package Microsoft.EntityFrameworkCore.Design
3. dotnet ef dbcontext scaffold "Server=localhost,1433;Database=OdeToCodeDB;User Id=sa;Password=<YourStrong@Passw0rd>;Trusted_Connection=false;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "DVDRentalContext" -d

To Update Models

1. dotnet ef dbcontext scaffold "Server=localhost,1433;Database=OdeToCodeDB;User Id=sa;Password=<YourStrong@Passw0rd>;Trusted_Connection=false;" Microsoft.EntityFrameworkCore.SqlServer -o Model -c "DVDRentalContext" -d --force

