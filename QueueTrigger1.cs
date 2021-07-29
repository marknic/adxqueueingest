using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MarkNic.Function
{
  public class PatientRec
    {
        public string eventDttm { get; set; }
        public string kafkaTime { get; set; }
        public string processDuration { get; set; }
        public string eventId { get; set; }
        public string changeSequence { get; set; }
        public string eventType { get; set; }
        public string patientId { get; set; }
        public string storeNbr { get; set; }
        public string rxNbr { get; set; }
        public string prevStoreNbr { get; set; }
        public bool prevRxNbr { get; set; }
        public string rxStatusCd { get; set; }
        public string drugId { get; set; }
        public object drugNonSystemCd { get; set; }
        public string drugName { get; set; }
        public string ndc { get; set; }
        public string gpi { get; set; }
        public int rxOriginalQty { get; set; }
        public int rxOriginalQtyDisp { get; set; }
        public int rxOriginalDaysSupply { get; set; }
        public int totalQtyPrescribed { get; set; }
        public int totalQtyDispensed { get; set; }
        public string refillsByDttm { get; set; }
        public object fillAutoInd { get; set; }
        public string fillUnlimitedInd { get; set; }
        public int originCd { get; set; }
        public object cobPlanId { get; set; }
        public string rx90DayPrefInd { get; set; }
        public string rx90DayPrefDttm { get; set; }
        public object rx90DayPrefStatCd { get; set; }
        public object rx90DayPrefStatDttm { get; set; }
        public Fillstatus fillStatus { get; set; }
        public string[] changedProperties { get; set; }
    }

  public class PatientRecOut
    {
        public string xActionId { get; set; }
        public string eventDttm { get; set; }
        public string kafkaTime { get; set; }
        public string processDuration { get; set; }
        public string eventId { get; set; }
        public string changeSequence { get; set; }
        public string eventType { get; set; }
        public string patientId { get; set; }
        public string storeNbr { get; set; }
        public string rxNbr { get; set; }
        public string prevStoreNbr { get; set; }
        public bool prevRxNbr { get; set; }
        public string rxStatusCd { get; set; }
        public string drugId { get; set; }
        public object drugNonSystemCd { get; set; }
        public string drugName { get; set; }
        public string ndc { get; set; }
        public string gpi { get; set; }
        public int rxOriginalQty { get; set; }
        public int rxOriginalQtyDisp { get; set; }
        public int rxOriginalDaysSupply { get; set; }
        public int totalQtyPrescribed { get; set; }
        public int totalQtyDispensed { get; set; }
        public string refillsByDttm { get; set; }
        public object fillAutoInd { get; set; }
        public string fillUnlimitedInd { get; set; }
        public int originCd { get; set; }
        public object cobPlanId { get; set; }
        public string rx90DayPrefInd { get; set; }
        public string rx90DayPrefDttm { get; set; }
        public object rx90DayPrefStatCd { get; set; }
        public object rx90DayPrefStatDttm { get; set; }
    }

    public class Fillstatus
    {
        public string eventDttm { get; set; }
        public int fillNbr { get; set; }
        public int fillNbrDispensed { get; set; }
        public string fillStatusCd { get; set; }
        public int fillQtyDispensed { get; set; }
        public int fillDaysSupply { get; set; }
        public object partialFillCd { get; set; }
        public float fillLabelPriceAmt { get; set; }
        public float fillRetailPriceAmt { get; set; }
        public string fillPayMethodCd { get; set; }
        public object planId { get; set; }
        public string fillEstPickUpDttm { get; set; }
        public string fillEnteredDttm { get; set; }
        public object fillDataRevDttm { get; set; }
        public object fillVerifiedDttm { get; set; }
        public object fillSoldDttm { get; set; }
        public object fillDeletedDttm { get; set; }
        public object fillAdjudicationCd { get; set; }
        public object fillAdjudicationDttm { get; set; }
        public string fillRejectReason { get; set; }
        public int dlRejectCd01 { get; set; }
        public object dlRejectCd02 { get; set; }
        public object dlRejectCd03 { get; set; }
        public object dlRejectCd04 { get; set; }
        public object dlRejectCd05 { get; set; }
        public object expCode { get; set; }
        public object expSubCd { get; set; }
        public object bin_nbr { get; set; }
        public object plan_group_nbr { get; set; }
        public string fill_type_cd { get; set; }
        public string fill_src_cd { get; set; }
        public object third_party_plan_id { get; set; }
        public object prcs_ctrl_nbr { get; set; }
        public object cob_ind { get; set; }
        public string pbr_id { get; set; }
        public string rx_daw_ind { get; set; }
        public object fill_delete_ind { get; set; }
        public object expResCd { get; set; }
    }




  public static class QueueTrigger1
    {
        [FunctionName("QueueTrigger1")]
        public static async Task RunAsync(
          [QueueTrigger("ingest-queue", Connection = "processdatafunctionstore_STORAGE")] string myQueueItem,
          [Blob("jsonmsgslite/datadrive/{queueTrigger}.msg.json", FileAccess.Read, Connection = "CustomerData_STORAGE")] string blobString,
          [EventHub("dest", Connection = "ADX-EG-marknicadx_ProcessDataFunction_EVENTHUB")] IAsyncCollector<string> outputEvents,
          ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processing: {myQueueItem}");

            var patientRecs = JsonConvert.DeserializeObject<PatientRecOut[]>(blobString);

            foreach (var rec in patientRecs)
            {
              if (rec.prevRxNbr) {

                rec.xActionId = Guid.NewGuid().ToString();

                var jsonRec = JsonConvert.SerializeObject(rec);

                await outputEvents.AddAsync(jsonRec);
              }
            }


            // var kustoConnectionStringBuilderDM =
            //     new KustoConnectionStringBuilder(@"https://marknicadx.eastus.kusto.windows.net").WithAadApplicationKeyAuthentication(
            //         applicationClientId: "f1dc6c5c-7638-4f4e-8778-557023230915",
            //         applicationKey: "_.G5kDuNE5O-h5u~iGGEYxKb5_s6f~zHGL",
            //         authority: "72f988bf-86f1-41af-91ab-2d7cd011db47");

            // Create an ingest client
            // Note, that creating a separate instance per ingestion operation is an anti-pattern
            // IngestClient classes are thread-safe and intended for reuse
            // var client = KustoIngestFactory.CreateDirectIngestClient(kustoConnectionStringBuilderDM);

            // var props = new KustoIngestionProperties("functiondata", "patientTable")
            // {
            //     Format = DataSourceFormat.json
            // };

            // using var reader = new StreamReader(blobStream, Encoding.UTF8);

            // string value = reader.ReadToEnd();

            // var patientRecs = JsonConvert.DeserializeObject<PatientRec[]>(value);

            // foreach (var rec in patientRecs)
            // {
            //   if (rec.prevRxNbr) {
            //     var jsonRec = JsonConvert.SerializeObject(rec);

            //     var stream = new MemoryStream(Encoding.ASCII.GetBytes(jsonRec));

            //     var result = await client.IngestFromStreamAsync(stream, props);
            //   }
            // }

            // client.Dispose();
        }
    }
}
