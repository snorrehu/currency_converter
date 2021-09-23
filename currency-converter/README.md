# Super Duper Currency Converter
This is an .NET MVC application that takes two currencies, an amount and optionally a date, and converts the amount from one currency to another. 

Simply open the project in Visual Studio and run with Docker.

NOTE: You might need to edit the url in _Layout.cshtml, line 50, to the port assigned on your specific machine.

Room for improvements:

1. Don't store API keys in source code: Can be stored as an environment variable on the server, in a .env file or using a secret storage solution like Hashicorp Vault for instance.
2. Better error handling: API errors should be handled and response should indicate what sort of error has occured (e.g. fixer.io only handles EUR as base currency for the free version.)
3. Add gitignore..

+++