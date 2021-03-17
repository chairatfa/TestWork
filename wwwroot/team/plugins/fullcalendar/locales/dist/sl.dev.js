"use strict";

function _typeof(obj) { if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") { _typeof = function _typeof(obj) { return typeof obj; }; } else { _typeof = function _typeof(obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }; } return _typeof(obj); }

(function (global, factory) {
  (typeof exports === "undefined" ? "undefined" : _typeof(exports)) === 'object' && typeof module !== 'undefined' ? module.exports = factory() : typeof define === 'function' && define.amd ? define(factory) : (global = global || self, (global.FullCalendarLocales = global.FullCalendarLocales || {}, global.FullCalendarLocales.sl = factory()));
})(void 0, function () {
  'use strict';

  var sl = {
    code: "sl",
    week: {
      dow: 1,
      doy: 7 // The week that contains Jan 1st is the first week of the year.

    },
    buttonText: {
      prev: "Prejšnji",
      next: "Naslednji",
      today: "Trenutni",
      month: "Mesec",
      week: "Teden",
      day: "Dan",
      list: "Dnevni red"
    },
    weekLabel: "Teden",
    allDayText: "Ves dan",
    eventLimitText: "več",
    noEventsMessage: "Ni dogodkov za prikaz"
  };
  return sl;
});