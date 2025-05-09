
Clone the project in your computer

DataBaseSetUp
	Need to set your local or any sqlServer database connection string in appsetting.json
	 "ConnectionStrings": {
		"CoffeeBeansDbConnection": "Server=<Your local sql server name>;Database=CoffeeBeansDb;Trusted_Connection=True;MultipleActiveResultSets=true"
	}
Migration Command 
	Need to run below command before project run
	dotnet ef --project <Your Local Path Wwere clone this repo>\CoffeeBeansDemo\Src\Infrastructure\CoffeeBeansDemo.Persistence --startup-project <Your Local Path Where clone this repo>\CoffeeBeansDemo\Src\Presentation\CoffeeBeansDemo.Api migrations add Initial

Running “bean of the day” schedule every 24 hour on coravel scheduler 
	"CronExpressionForScheduleBOTD": "0 0 * * *" in you appsetting.json;
	"CronExpressionForScheduleBOTD": "*/2 * * * *" setting this reandomely select “bean of the day” every two minutes more info can fine on https://crontab.guru/ 
	
Run the Api project 
	In Swagger Excute DataSeed API

Rund the Ui project 
```sh
npm run dev
```

Run e2e test
Need make sure backend and frontend application running in background
```sh
npm run test:e2e
```

*/2 * * * *