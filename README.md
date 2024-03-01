# Categorize Trade Application
## Description
This C# solution follows SOLID principles by separating concerns into distinct classes/interfaces, 
providing flexibility for future modifications and extensions. 
The NUnit tests ensures that the categorization logic works as expected for different trade scenarios.

You can find a T-SQL solution for this issue at CategorizeTradeApp files called 'tradeCategorize.sql'.

In this Domain-Driven Design case, the Strategy design pattern would fit best. The Strategy pattern defines a family of algorithms, encapsulates each one, and makes them interchangeable. 
This allows the client (in this case, the code that categorizes trades) to vary its behavior based on the selected algorithm without modifying its structure.

In this scenario, the algorithms correspond to the different types of risk categories (LOWRISK, MEDIUMRISK, HIGHRISK), and the Strategy pattern would allow us to define each risk category as a separate Strategy. 
This way, when new rules are added, removed, or modified in the future, we can easily extend the system without changing the existing code.

By implementing this pattern, we encapsulate the logic for each risk category in separate classes, making it easy to manage, modify, 
or extend the categorization rules without affecting the overall structure of the categorization process.
Strategy Design Pattern: https://sourcemaking.com/design_patterns/strategy
![Cópia de Search](https://github.com/Gustavo-Fortunato/CategorizeTradeApp/assets/67340658/a5bd2763-9a3a-4145-b28e-240efdaddffe)
