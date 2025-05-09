As per the challenge I have done both the challenge. And also Integrated the API from backend to frontend
Tech used in backend Server Side Application  
•	C#
•	.NET Core 8
•	.Entity Framework Core
•	Coravel Scheduler
•	Hosted Service
•	MS Test
•	In-Memory Test
Tech used in frontend Client Side Application 
•	Vue CLI
•	Vue 3.5
•	TailwindCSS
•	Pinia store
•	Playwright for e2e
•	Axios
•	Ag-grid
•	Vite
•	Typescript
•	Headlessui/vue
•	Heroicons/vue
•	Vue-router

I have used clean architecture style with mediator pattern to solve backend application. I know this is small application and I possibly easily solve using 3 tier architecture.
I just wanted to demo my ability to solve problem in complex way so in real word, if I have same situation I'll fill comfortable doing it.

Just for clarity I have learn lot from this challenge new things I have learned are Pinia, TailwindCSS and Vue 3.5 it bit difference when I last used 4-5 years ago.
In front end application I possible more use of typescript, if i have time then I'll separate home page more in components like filter, Nav, search, Sort etc. 
HomeView should be wrapper of all this component this lacking in my solution in frontend.

In backend I used caravel scheduler which run on hosted Service to make “bean of the day” mechanic easy and configurable. We can run making “bean of the day” in our chosen time of the day, multiple time of the day by just configuring crone expression.
You can find more information about crone expression https://crontab.guru/. Also add extra API to seed the data from json file 

There is lot more I can do in this project like I can add Identity database feature for login and authorising user and create policy base access to API. 
Also able to add middleware for better error handling, add more test coverage as missing some sinario in the test. 


I have configure e2e test as well and have added couple of test to start with but not cover all scenarios but you can test this scenario manually.

I look forward to here from you about feedback on my problem solving skills.

Best Regards 
Chhagan Kuchhadiya
