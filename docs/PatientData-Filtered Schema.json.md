# PatientData Filtered JSON Schemna

```JSON
{
  "$schema": "http://json-schema.org/draft-04/schema#",
  "type": "object",
  "properties": {
    "xActionId": {
      "type": "string"
    },
    "eventDttm": {
      "type": "string"
    },
    "kafkaTime": {
      "type": "string"
    },
    "processDuration": {
      "type": "string"
    },
    "eventId": {
      "type": "string"
    },
    "changeSequence": {
      "type": "string"
    },
    "eventType": {
      "type": "string"
    },
    "patientId": {
      "type": "string"
    },
    "storeNbr": {
      "type": "string"
    },
    "rxNbr": {
      "type": "string"
    },
    "prevStoreNbr": {
      "type": "string"
    },
    "prevRxNbr": {
      "type": "boolean"
    },
    "rxStatusCd": {
      "type": "string"
    },
    "drugId": {
      "type": "string"
    },
    "drugNonSystemCd": {
      "type": "string"
    },
    "drugName": {
      "type": "string"
    },
    "ndc": {
      "type": "string"
    },
    "gpi": {
      "type": "string"
    },
    "rxOriginalQty": {
      "type": "integer"
    },
    "rxOriginalQtyDisp": {
      "type": "integer"
    },
    "rxOriginalDaysSupply": {
      "type": "integer"
    },
    "totalQtyPrescribed": {
      "type": "integer"
    },
    "totalQtyDispensed": {
      "type": "integer"
    },
    "refillsByDttm": {
      "type": "string"
    },
    "fillAutoInd": {
      "type": "string"
    },
    "fillUnlimitedInd": {
      "type": "string"
    },
    "originCd": {
      "type": "integer"
    },
    "cobPlanId": {
      "type": "string"
    },
    "rx90DayPrefInd": {
      "type": "string"
    },
    "rx90DayPrefDttm": {
      "type": "string"
    },
    "rx90DayPrefStatCd": {
      "type": "string"
    },
    "rx90DayPrefStatDttm": {
      "type": "string"
    }
  },
  "required": [
    "xActionId",
    "eventDttm",
    "kafkaTime",
    "processDuration",
    "eventId",
    "changeSequence",
    "eventType",
    "patientId",
    "storeNbr",
    "rxNbr",
    "prevStoreNbr",
    "prevRxNbr",
    "rxStatusCd",
    "drugId",
    "drugNonSystemCd",
    "drugName",
    "ndc",
    "gpi",
    "rxOriginalQty",
    "rxOriginalQtyDisp",
    "rxOriginalDaysSupply",
    "totalQtyPrescribed",
    "totalQtyDispensed",
    "refillsByDttm",
    "fillAutoInd",
    "fillUnlimitedInd",
    "originCd",
    "cobPlanId",
    "rx90DayPrefInd",
    "rx90DayPrefDttm",
    "rx90DayPrefStatCd",
    "rx90DayPrefStatDttm"
  ]
}
```
