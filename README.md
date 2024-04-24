# Labb3-API
*API-anrop:* 

**POST/persons**

***första personen:***
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

<br />
***andra personen:***
<br />
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
<br />
**GET/persons**
Execute för att se personernas personId
<br />
**PUT/persons/{personId}/interests**
***personId:*** personId för "Maria"
<br />
***req-body:*** 
[
  {
    "interestName": "Odla",
    "interestDescription": "Blommor i trädgården"
  }
]
<br />
**GET/persons/{personId}/interests**
***personId:*** personId för "Maria"

Execute för att se vilket interestId "Odla" har 
<br />
**PUT /persons/{personId}/interests/{interestId}/links**
***personId:*** personId för "Maria"
***interestId:*** interestId för "Odla"
<br />
i req-body: 
<br />
[
  {
    "url": "Odla.nu"
  },
  {
    "url": "Grönafingrar.se"
  }
]
<br />
**GET/persons/{personId}/interests/links**
***personId***: personId för "Maria"

Execute för att se de nya länkarna kopplade till Maria
