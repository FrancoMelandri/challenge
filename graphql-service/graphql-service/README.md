# GraphQL service


Allow a client to get information from the servcies using the GraphQL ssyntax.

---------------

Search results:

Request:

POST http://localhost:19091/api/graphql

{"query":"{\nproductList(search: \"Name\") {\n    search\n  items\n{name\ncode\n}}\n}\n\n","variables": null}

Response:

{
    "data": {
        "productList": {
            "search": "Name",
            "items": [
                {
                    "name": "Name 1",
                    "code": "Item1"
                },
                {
                    "name": "Name 2",
                    "code": "Item2"
                },
                {
                    "name": "Name 3",
                    "code": "Item3"
                },
                {
                    "name": "Name 4",
                    "code": "Item4"
                },
                {
                    "name": "Name 5",
                    "code": "Item5"
                }
            ]
        }
    }
}

-------------
Product details:

Request:

POST http://localhost:19091/api/graphql

{"query":"{\nproduct(code: \"Item1\") {\n    code\nname\nbrand\ndescription  }\n}\n\n","variables": null}

Response:

{
    "data": {
        "product": {
            "code": "Item1",
            "name": "Name 1",
            "brand": "Brand 1",
            "description": "Description 1"
        }
    }
}
