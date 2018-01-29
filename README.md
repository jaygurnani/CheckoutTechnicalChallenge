# Check Technical Test
## Things built:
* WebAPI that has 6 endpoint: 
    1. Create a basket, 
    2. Get a basket, 
    3. Clear a basket, 
    4. Remove items from a basket
    5. Add items to a basket, 
    6. Update an item in the basket
* The code in the WebAPI is seperated into Models, Controllers and Repositories
* Validation is done in the Controller
* All repositories now use an interface. This allows us to switch the underlying system without breaking code.
* A file is placed in the C drive - "C:\Database.json" serves as a file based storage mechanism. 
* Variables are made private when only used within the same class and are prefixed with "_".
# Steps to Run
1. Open Visual studio as an Administrator.
2. Run the Repository and SDK Unit Tests in the Unit Test project.