# Nex4

# Calculator Challenge

## Summary
This is a simple calculator that supports **addition** operations given a single formatted string. It is implemented as a console application using C# and includes unit tests. The project is structured to prioritize readability and separation of concerns, with each requirement implemented as a separate commit.

## Requirements
### 1. Support a maximum of 2 numbers using a comma delimiter
- Input: `20` → Output: `20`
- Input: `1,5000` → Output: `5001`
- Input: `4,-3` → Output: `1`
- Throws an exception when more than 2 numbers are provided.
- Empty input or missing numbers are converted to `0`.
- Invalid numbers are converted to `0`. Example: `5,tytyt` → `5`

### 2. Remove the maximum constraint for numbers
- Example: `1,2,3,4,5,6,7,8,9,10,11,12` → `78`

### 3. Support a newline character as an alternative delimiter
- Example: `1\n2,3` → `6`

### 4. Deny negative numbers
- Throws an exception that includes all the negative numbers provided.

### 5. Make any value greater than 1000 an invalid number
- Example: `2,1001,6` → `8`

### 6. Support a custom delimiter of a single character
- Use the format: `//{delimiter}\n{numbers}`
- Example: `//#\n2#5` → `7`
- Example: `//,\n2,ff,100` → `102`
- All previous formats should also be supported.

### 7. Support a custom delimiter of any length
- Use the format: `//[{delimiter}]\n{numbers}`
- Example: `//[***]\n11***22***33` → `66`
- All previous formats should also be supported.

### 8. Support multiple delimiters of any length
- Use the format: `//[{delimiter1}][{delimiter2}]...\n{numbers}`
- Example: `//[*][!!][r9r]\n11r9r22*hh*33!!44` → `110`
- All previous formats should also be supported.

## Stretch Goals
### 1. Display the formula used to calculate the result
- Example: `2,,4,rrrr,1001,6` → `2+0+4+0+0+6 = 12`

### 2. Allow the application to process entered entries until Ctrl+C is used
- The application will keep running and allow for continuous input processing until manually terminated.

### 3. Allow the acceptance of arguments for the following:
- **Alternate delimiter** in step #3.
- **Toggle whether to deny negative numbers** in step #4.
- **Set an upper bound** in step #5.

### 4. Use Dependency Injection (DI)
- The project implements Dependency Injection for better separation of concerns.

### 5. Support subtraction, multiplication, and division operations
- In addition to addition, the calculator supports subtraction, multiplication, and division operations.

## How to Run
1. Clone the repository:
    ```bash
    git clone <repository-url>
    ```
2. Navigate to the project directory:
    ```bash
    cd calculator-challenge
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the application:
    ```bash
    dotnet run
    ```

5. Optionally, you can pass arguments to change the delimiter, toggle negative number restrictions, and set an upper bound:
    ```bash
    dotnet run -- "," false 500
    ```

## Unit Tests
The project includes unit tests to verify the correctness of each requirement. To run the tests:
```bash
dotnet test
