# Labb3-API: API-anrop:

## POST/persons
# I request body:
<br />
### första personen:
<br />
{
  "firstName": "Maria",
  "lastName": "Andersson",
  "phoneNumber": "0701234567",
  "interests": [
    {
      "interestName": "Målning",
      "interestDescription": "Målning med akrylfärger",
      "links": [
        {
          "url": "https://exempel.com/malning-1"
        },
        {
          "url": "https://exempel.com/malning-2"
        }
      ]
    },
    {
      "interestName": "Läsning",
      "interestDescription": "Romaner och biografier",
      "links": [
        {
          "url": "https://exempel.com/bok-1"
        },
        {
          "url": "https://exempel.com/bok-2"
        }
      ]
    }
  ]
}
