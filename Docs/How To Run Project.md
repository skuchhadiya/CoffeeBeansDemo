
Clone the project in your computer

	https://github.com/skuchhadiya/CoffeeBeansDemo.git

Copy above link and start Visual studio and select clone repository project and paste above link.

Close Visual studio after cloning repository.

Go to repository diretory and open file CoffeeBeansDemo.sln in Visual studio.


Data base set-up need using your local or any sqlServer database connection string in appsetting.json
	
	"ConnectionStrings": {
		"CoffeeBeansDbConnection": "Server=<Your local sql server name>;Database=CoffeeBeansDb;Trusted_Connection=True;MultipleActiveResultSets=true"
	}

Migration command need to run as per below script before project run
	
	dotnet ef --project <Your Local Path Wwere clone this repo>\CoffeeBeansDemo\Src\Infrastructure\CoffeeBeansDemo.Persistence --startup-project <Your Local Path Where clone this repo>\CoffeeBeansDemo\Src\Presentation\CoffeeBeansDemo.Api migrations add Initial

Running “bean of the day” schedule every 24 hour on coravel scheduler 
	
	"CronExpressionForScheduleBOTD": "0 0 * * *" This is for reandomely select “bean of the day” every day at minight 00:00

Running “bean of the day” schedule every 2 minutes on coravel scheduler 

	"CronExpressionForScheduleBOTD": "*/2 * * * *" 
	
For information about how to set crone expression please visit https://crontab.guru/ 
	
Run the api project 

	In Swagger Excute SeedDataInTheDatabase API

Run the Ui project 
```sh
npm i
npm run dev
```

Run e2e test need to make sure your backend and frontend application running in background
```sh
npm run test:e2e
```