MigratePersistence:
	dotnet ef migrations add InitialCreate --project Persistence -c DbContext --startup-project Api

AddSeedPersistence:
	dotnet ef migrations add AddSeedData  --project Persistence  -c DbContext --startup-project Api

MigrateUpdatePersistence:
	dotnet ef database update --project Persistence/ -c DbContext --startup-project Api
	
MigrateIdentity:
	dotnet ef migrations add InitialCreate --project Identity/ -c CinemaAppIdentityDbContext --startup-project Api

AddSeedIdentity:
	dotnet ef migrations add AddSeedData  --project Identity  -c CinemaAppIdentityDbContext --startup-project Api

MigrateUpdateIdentity:
	dotnet ef database update --project Identity/ -c CinemaAppIdentityDbContext --startup-project Api