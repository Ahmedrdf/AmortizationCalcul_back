using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstResultsController : Controller
    {
        public IFirstResultsService _firstResultsService;

        public FirstResultsController(IFirstResultsService firstResultsService)
        {
            _firstResultsService = firstResultsService;
        }


        /// <summary>
        /// Get All Results
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("results")]
        public ActionResult GetResults()
        {
            var objList = _firstResultsService.GetFirstResults();
            return Ok(objList);
        }

        /// <summary>
        /// Get Result By ID 
        /// </summary>
        /// <param name="FirstResultId"></param>
        /// <returns></returns>
        [HttpGet("", Name = "GetFirstResult ")]
        public IActionResult GetResult(int FirstResultId)
        {
            var obj = _firstResultsService.GetFirstResults(FirstResultId);

            //if (obj == null) return NotFound();
            return Ok(obj);
        }

        /// <summary>
        /// Create & Return  FirstResult 
        /// </summary>
        /// <param name="montantDachat"></param>
        /// <param name="fondPropre"></param>
        /// <param name="duree"></param>
        /// <param name="intertAnnuel"></param>
        /// <param name="capital"></param>
        /// <returns></returns>
        [HttpPost("", Name = "GetFirst ")]
        public IActionResult Results(double montantDachat, double fondPropre, int duree, double intertAnnuel,
            double capital)
        {
            var firstResult = new FirstResults();

            firstResult.MontantDachat = montantDachat;
            firstResult.FondPropre = fondPropre;
            firstResult.duree = duree;
            firstResult.Capital = capital;
            firstResult.FraisDachat = 10 * montantDachat / 100;


            firstResult.MentantEmpBrut = montantDachat - fondPropre + firstResult.FraisDachat;
            firstResult.FraisDhypotheque = firstResult.MentantEmpBrut * 2 / 100;
            firstResult.MentantEmpNet = Math.Round(firstResult.MentantEmpBrut + firstResult.FraisDhypotheque,2);

            firstResult.InteretAnnuel = intertAnnuel;

            var modi = decimal.Divide(1, 12).ToString();
            firstResult.InteretMensuel = Math.Round(Math.Pow(1 + firstResult.InteretAnnuel, double.Parse(modi)) - 1, 3);

            //var InteretMensuel = Math.Pow((1 + firstResult.InteretAnnuel), (modi)) - 1;

            firstResult.Mensualite = Math.Round(Math.Pow(
                capital * firstResult.InteretMensuel * (1 + firstResult.InteretMensuel),
                duree / Math.Pow(1 + firstResult.InteretMensuel, duree - 1)), 2);


            var initAmortissement = new Amortissement();

            initAmortissement.Periode = 1;
            initAmortissement.Mensualite = firstResult.Mensualite;
            initAmortissement.SoldeDebut = firstResult.MentantEmpNet;
            initAmortissement.Interet = Math.Round(initAmortissement.SoldeDebut * firstResult.InteretMensuel, 2);
            initAmortissement.CapitaleRembourse = initAmortissement.Mensualite - initAmortissement.Interet;
            initAmortissement.SoldeFin = initAmortissement.SoldeDebut - initAmortissement.CapitaleRembourse;


            var tabAmortissement = new List<Amortissement>();

            tabAmortissement.Add(initAmortissement);

            firstResult.Amortissements = new List<Amortissement>();


            for (var i = 1; i < duree; i++)
            {
                var amortissement = new Amortissement();

                amortissement.Periode = i + 1;
                amortissement.SoldeDebut = tabAmortissement[i - 1].SoldeFin;
                amortissement.Mensualite = firstResult.Mensualite;
                amortissement.Interet = Math.Round(amortissement.SoldeDebut * firstResult.InteretMensuel, 2);
                amortissement.CapitaleRembourse = Math.Round(amortissement.Mensualite - amortissement.Interet, 2);
                amortissement.SoldeFin = Math.Round(amortissement.SoldeDebut - amortissement.CapitaleRembourse, 2);


                tabAmortissement.Add(amortissement);
            }

            firstResult.Amortissements = tabAmortissement;

            _firstResultsService.CreatFirstResults(firstResult);
            return Ok
                (firstResult);
        }

        /// <summary>
        /// Delete what you want 
        /// </summary>
        /// <param name="ResultId"></param>
        /// <returns></returns>
        [HttpDelete("{ResultId}", Name = "DeleteResult")]
        public IActionResult DeleteNationalPark(int ResultId)
        {
            if (!_firstResultsService.FirstResultsExist(ResultId)) return NotFound();
            var ObjToDelete = _firstResultsService.GetFirstResults(ResultId);
            if (!_firstResultsService.DeleteFirstResults(ObjToDelete)) return StatusCode(500, ModelState);
            return NoContent();
        }
    }
}