# GeeksDirectory

Web site for assessment of competence in technologies.

## Demo

http://geeks-directory.azurewebsites.net/

## Functionality

1. Non-authentificated user can see list of others profiles or search for them.
2. User profile contains: Name, Surname, Middle Name, City, Email and etc.
3. User can search by Name, Surname, Middle name, City.
4. User can sign up and be authentificated.
5. Authentificated user can add new skills and make assessment to existing ones.
6. Score assessments for skills is limited to range between 0 to 5.
7. Each skill can have multiple score assessments. Skill should have an average score.
8. User is not allowed to remove skills.

## Build

1. Check `ConnectionStrings` in `appsettings.development.json`. There will be created a new **sqlite** db when applied migrations;
2. Open terminal with the path of project `GeeksDirectory.Data`. Update database with migrations `dotnet ef database update -s "../GeeksDirectory.Web"`;
3. Run angular in watch mode `ng serve` or `npm run start`;
4. Run in Visual Studio;

## TODO:

1. ~~Add Web API methods.~~
2. ~~Make database with EF Core code-first;~~
3. ~~Add API model validations;~~
4. ~~Add Oauth Token authentification;~~
5. ~~Add SignIn page;~~
6. ~~Add Registration page;~~
7. ~~Add View Profile page;~~
8. ~~Add Cookie/LocalStorage support;~~
9. ~~Add Edit Profile page~~;
10. ~~Add Skills adding functionality~~;
11. ~~Add Skills assessment functionality~~;
12. ~~Update layout for small screen support~~;
13. Search functionality on front-end side;
14. ~~Limit editing profile to personal one on server side;~~
15. ~~Add more validations for password and skill's name~~;
16. Get previous score when evaluate skill;
17. Add tests;
18. ~~Refactoring / code review~~;
19. ~~Seed database~~;
20. Add pagination;
    ...
