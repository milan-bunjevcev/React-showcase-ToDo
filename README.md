# React-showcase-ToDo

Simple ToDo application with the purpose of showcasing basic concepts of React. 

## How to run back-end:
- Application is implemented using dotnet 8, make sure you have it installed.
- From the root of the repository navigate to 'ToDo.Api' directory (`cd ToDo.Api`)
- Start the application by running command: `dotnet run --project ToDo.Api/ToDo.Api.csproj`
- To open the swagger open: `http://localhost:5111/swagger/index.html` in browser

## How to run front-end:
- From the root of the repository navigate to 'webapp' directory (`cd webapp`)
- Install node modules by running: `npm install`
- Start react application by running: `npm start`
- In `Constants.ts` file you can find back-end base url that react will use. If your backend is running on different URL, please update the constant.
