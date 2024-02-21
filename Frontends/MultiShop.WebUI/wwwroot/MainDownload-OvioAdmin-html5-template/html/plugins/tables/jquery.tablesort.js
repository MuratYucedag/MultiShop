/*!
 * Author: Tony Brix, me@tonybrix.info
 * License: MIT 
 * Description: Sort tables by clicking on headers
 */
(function ($, undefined) {
	"use strict";
	var pluginName = "tablesort";
	$[pluginName] = function (el, options) {
		var plugin;
		if ($(el).data(pluginName)) {
			plugin = $(el).data(pluginName);
		} else {
			// To avoid scope issues, use 'plugin' instead of 'this'
			// to reference this class from internal events and functions.
			plugin = this;

			// Access to jQuery and DOM versions of element
			plugin.$table = $(el);

			// Add a reverse reference to the DOM object
			plugin.$table.data(pluginName, plugin);
		}

		if (typeof options === "object" || options === undefined) {
			plugin._init(options);
		} else if (typeof options === "string" && options.substring(0, 1) !== "_" && typeof plugin[options] === "function") {
			plugin[options].apply(plugin, Array.prototype.slice.call(arguments, 1));
		} else {
			throw "Invalid Arguments";
		}
	};

	var pluginPrototype = {
		_defaults: {
			sorttypes: {
				date: function (a, b) {
					var av = new Date(a);
					var bv = new Date(b);
					if (av < bv) {
						return -1;
					}
					if (av > bv) {
						return 1;
					}
					return 0;
				},
				time: function (a, b) {
					var av, bv;
					var aneg = (a.substring(0, 1) === "-");
					var bneg = (b.substring(0, 1) === "-");
					if (aneg && bneg) {
						av = new Date("2000-01-01 " + b.substring(1));
						bv = new Date("2000-01-01 " + a.substring(1));
					} else if (aneg || bneg) {
						av = +bneg;
						bv = +aneg;
					} else {
						av = new Date("2000-01-01 " + a);
						bv = new Date("2000-01-01 " + b);
					}
					if (av < bv) {
						return -1;
					}
					if (av > bv) {
						return 1;
					}
					return 0;
				},
				number: function (a, b) {
					var av = Number(a.replace(/,/g, ""));
					var bv = Number(b.replace(/,/g, ""));
					if (av < bv) {
						return -1;
					}
					if (av > bv) {
						return 1;
					}
					return 0;
				},
				string: function (a, b) {
					var av = a.toLowerCase();
					var bv = b.toLowerCase();
					if (av < bv) {
						return -1;
					}
					if (av > bv) {
						return 1;
					}
					return 0;
				}
			},
			initColumn: false,
			initDirection: "asc"
		},
		_init: function (options) {
			var plugin = this;

			if (plugin.initialized) {
				throw "Already Initialized";
			}
			if (options === undefined) {
				plugin.options = plugin._defaults;
			} else {
				options.sorttypes = $.extend({}, plugin._defaults.sorttypes, options.sorttypes);
				plugin.options = $.extend({}, plugin._defaults, options);
			}

			plugin.$thead = $("thead", plugin.$table);
			plugin.$tbody = $("tbody", plugin.$table);
			plugin.$ths = $("tr th", plugin.$thead);
			plugin.$tds = $("tr td", plugin.$tbody);
			plugin.$rows = $("tr", plugin.$tbody);

			plugin.$table.addClass("tablesort");
			plugin.$ths.each(function (i) {
				var $this = $(this);
				var column = "tablesort-" + i;
				$this.addClass(column).data({
					column: column
				});
				plugin.$tds.filter(":nth-child(" + (i + 1) + ")").addClass(column);
			}).wrapInner("<span class='tablesort-label' />").append("<span class='tablesort-arrows'><div><span class='tablesort-sortdesc'>&#9650;</span><span class='tablesort-sortasc'>&#9660;</span></div></span>").wrapInner("<div class='tablesort-th' />").on("click.tablesort", function (e) {
				var $this = $(this);
				if ($this.hasClass("sortable")) {
					var $target = $(e.target);
					var sort = plugin.$thead.data().sort || " ";
					var current = sort.split(" ");
					var column = $this.data().column;
					var direction = "asc";
					if ($target.hasClass("tablesort-sortdesc") || (current[0] === column && current[1] === "asc" && !$target.hasClass("tablesort-sortasc"))) {
						direction = "desc";
					}
					if (sort === column + " " + direction) {
						return;
					}
					if (current[0]) {
						$("." + current[0], plugin.$thead).removeClass("tablesort-" + current[1]);
					}
					plugin._sort(column, direction);
				}
			});

			if (plugin.options.initColumn !== false) {
				var column = ($.isNumeric(plugin.options.initColumn) ? "tablesort-" + plugin.options.initColumn : plugin.options.initColumn);
				var direction = (plugin.options.initDirection.toLowerCase() === "desc" ? "desc" : "asc");
				plugin._sort(column, direction);
			}

			plugin.initialized = true;
		},
		destroy: function () {
			var plugin = this;

			plugin.$ths.off(".tablesort").each(function (i) {
				var $this = $(this);
				var column = "tablesort-" + i;
				$this.removeClass(column).unwrapInner("span.tablesort-th").unwrapInner("span.tablesort-label").find(".tablesort-arrows").remove();
				delete $this.data().column;
				plugin.$tds.filter(":nth-child(" + (i + 1) + ")").removeClass(column);
			});

			delete plugin.$table.data()[pluginName];
		},
		_sort: function (column, direction) {
			var plugin = this;
			var $this = $("." + column, plugin.$thead);
			//TODO: if ctrl key down then add sort
			var sorttype = $this.data().sorttype || "string";
			plugin.$thead.data({sort: column + " " + direction});
			$this.addClass("tablesort-" + direction);
			//sort
			var sortdir = (direction === "asc" ? 1 : -1);
			plugin.$rows.sort(function (a, b) {
				var atext = $("." + column, a).text();
				var btext = $("." + column, b).text();
				return sortdir * plugin.options.sorttypes[sorttype](atext, btext);
			}).appendTo(plugin.$tbody);
		}
	};

	$[pluginName].prototype = pluginPrototype;

	$.fn[pluginName] = function (options) {
		return this.each(function () {
			new $[pluginName](this, options);
		});
	};

	$(function () {
		var $style = $("<style class='" + pluginName + "-stylesheet'>" +
				".tablesort-arrows{" +
				"display: none;" +
				"}" +
				".sortable{" +
				"cursor: pointer;" +
				"}" +
				".sortable .tablesort-th{" +
				"display: table;" +
				"width: 100%;" +
				"}" +
				".sortable .tablesort-arrows{" +
				"display: table-cell;" +
				"width: 1.1em;" +
				"vertical-align: middle;" +
				"}" +
				".sortable .tablesort-arrows div{" +
				"position: relative;" +
				"width: 1.1em;" +
				"min-height: 2.2em;" +
				"}" +
				".sortable .tablesort-label{" +
				"display: table-cell;" +
				"vertical-align: middle;" +
				"}" +
				".sortable .tablesort-sortdesc, .sortable .tablesort-sortasc{" +
				"position: absolute;" +
				"right: 0px;" +
				"color: #666;" +
				"}" +
				".sortable .tablesort-sortdesc{" +
				"top: 0px;" +
				"}" +
				".sortable .tablesort-sortasc{" +
				"top: 1em;" +
				"}" +
				".sortable.tablesort-desc .tablesort-sortdesc, .sortable.tablesort-asc .tablesort-sortasc{" +
				"color: #fff;" +
				"}" +
				"</style>");
		var $styles = $("head link[rel='stylesheet'], head style");
		if ($styles.length > 0) {
			$styles.eq(0).before($style);
		} else {
			$("head").append($style);
		}
	});

	// unwrapInner function
	// http://wowmotty.blogspot.com/2012/07/jquery-unwrapinner.html
	$.fn.extend({
		unwrapInner: function (selector) {
			return this.each(function () {
				var t = this,
						c = $(t).children(selector);
				if (c.length === 1) {
					c.contents().appendTo(t);
					c.remove();
				}
			});
		}
	});
}(jQuery));
