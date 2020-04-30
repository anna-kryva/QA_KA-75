# QA_KA-75
The KA-75 group's repository for the QA course (KPI)

**Branch name pattern:**  
`firstName.LastName_lab`

## Task 1  
Напишите свою имплементацию двусвязного списка, метод Add, GetCurrent, GetNext, GetPrevious  

## Task 2  
Write С# CompareVersions() method, which takes as parameters 2 strings. These strings are product versions. Product version consists of unlimited versions and subversions. Pattern for version is numbers and dot delimiters. If first version is greater than second method returns 1, if equals 0, if less -1.
Examples:  
`str1 = “1.2.3” str2 = “4.5.6” return -1`  
`str1 = “1” str2 = “1.0” return 0`  
`str1 = “1.1.0” str2 = “1.0.1” return 1`   

## Selenium  
The website to test is [www.sportlife.com](https://www.sportlife.ua/uk)  
To run all test at once, enter `npm run runner`.   
To run one test, change `package.json`:  
```
"scripts": {
    "test": "node ./node_modules/mocha/bin/mocha NAME_OF_FILE.js --timeout 100000"
}
```