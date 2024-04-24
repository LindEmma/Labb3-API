# API-anrop:

## POST/persons
### I request body:

### första personen:

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

### andra personen:

{
  "firstName": "Erik",
  "lastName": "Larsson",
  "phoneNumber": "0729876543",
  "interests": [
    {
      "interestName": "Fotboll",
      "interestDescription": "Spela och titta på fotboll",
      "links": [
        {
          "url": "https://exempel.com/fotboll-match-1"
        },
        {
          "url": "https://exempel.com/fotboll-match-2"
        }
      ]
    },
    {
      "interestName": "Resor",
      "interestDescription": "Utforska nya platser",
      "links": [
        {
          "url": "https://exempel.com/resmal-1"
        },
        {
          "url": "https://exempel.com/resmal-2"
        }
      ]
    }
  ]
}

## GET/persons

Execute för att se personernas personId

## PUT/persons/{personId}/interests

**personId:** personId för "Maria"

**req-body:** 
[
  {
    "interestName": "Odla",
    "interestDescription": "Blommor i trädgården"
  }
]
## GET/persons/{personId}/interests

**personId:** personId för "Maria"

Execute för att se vilket interestId "Odla" har 

## PUT /persons/{personId}/interests/{interestId}/links

**personId:** personId för "Maria"
**interestId:** interestId för "Odla"

**i req-body:** 

[
  {
    "url": "Odla.nu"
  },
  {
    "url": "Grönafingrar.se"
  }
]

## GET/persons/{personId}/interests/links

***personId***: personId för "Maria"

Execute för att se de nya länkarna kopplade till Maria
