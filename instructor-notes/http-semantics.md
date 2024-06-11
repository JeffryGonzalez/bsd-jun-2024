

# Resource Oriented Architecture

A Resource is an important thingy that you want to expose from your API.

A resource is identified through a URI (Uniform Resource Identifier)

https://api.company.com/hr/employees

- https: "Scheme" - either http or https (Transport Layer (TCP), HTTP is "Application Layer")

- api.company.com - "authority" server, DNS name or IP address of the server.

- /hr/employees - "path" (to the resource)
    - Types of Resources
        - Collections (like Employees, SoftwareCatalog, Issues)
        - Documents - singular.


https://api.company.com/hr/employees/bob-smith - 1096ms

{
    "id": "Bob Smith",
    "phone": "555-1212",
    "email": "bob@company.com"



GET https://api.company.com/hr/employees/bob-smith/manager

{
    "id": "Sue Jones",
    "phone": "555-1210",
    "email": "sue@company.com"
}

GET https://api.company.com/hr/employees/sue-jones

{
    "id": "Sue Jones",
    "phone": "555-1210",
    "email": "sue@company.com"
}

GET https://api.company.com/hr/employees/bob-smith/performance-history


"Steve Klabnik" - developer. "Always create new resources"

- Resources have a fixed set of things that we can allow.

- GET - select
- POST - insert used on collections (like Employees, Books, etc. ) - "Please consider adding this representation to your suborndinate resources)

- PUT - update
- DELETE - delete

GET /software/{id}/issues

POST /software/{id}/issues
Content-Type: application/json
Authorization: bearer 894098409

{
    "description": "Dang thing is broke",
    "impact": "Inconvenience",
   
    
}


POST /software/{id}/issues/questions
POST /software/{id}/issues/inconvniences
POST /software/{id}/issues/workstoppages
POST /software/{id}/issues/productionstoppages


