"use strict";

// Class definition
var KTChartsWidget1 = function () {
    var chart = {
        self: null,
        rendered: false
    };

    // Private methods
    var initChart = function() {
        var element = document.getElementById("kt_charts_widget_1");

        if (!element) {
            return;
        }

        var negativeColor = element.hasAttribute('data-kt-negative-color') ? element.getAttribute('data-kt-negative-color') : KTUtil.getCssVariableValue('--bs-success');

        var height = parseInt(KTUtil.css(element, 'height'));
        var labelColor = KTUtil.getCssVariableValue('--bs-gray-500');
        var borderColor = KTUtil.getCssVariableValue('--bs-border-dashed-color');

        var baseColor = KTUtil.getCssVariableValue('--bs-primary');

        var options = {
            series: [{
                name: 'مشترک',
                data: [20, 30, 20, 40, 60, 75, 65, 18, 10, 5, 15, 40, 60, 18, 35, 55, 20]
            }, {
                name: 'لغو اشتراک',
                data: [-20, -15, -5, -20, -30, -15, -10, -8, -5, -5, -10, -25, -15, -5, -10, -5, -15]
            }],
            chart: {
                fontFamily: 'inherit',
                type: 'bar',
                stacked: true,
                height: height,
                toolbar: {
                    show: false
                }
            },
            plotOptions: {
                bar: {
                    //horizontal: false,
                    columnWidth: "35%",
                    barHeight: "70%",
                    borderRadius: [6, 6]
                }
            },
            legend: {
                show: false
            },
            dataLabels: {
                enabled: false
            },
            xaxis: {
                categories: ['دی 5', 'دی 7', 'دی 9', 'دی 11', 'دی 13', 'دی 15', 'دی 17', 'دی 19', 'دی 20', 'دی 21', 'دی 23', 'دی 24', 'دی 25', 'دی 26', 'دی 24', 'دی 28', 'دی 29'],
                axisBorder: {
                    show: false
                },
                axisTicks: {
                    show: false
                },
                tickAmount: 10,
                labels: {
                    //rotate: -45,
                    //rotateAlways: true,
                    style: {
                        colors: [labelColor],
                        fontSize: '12px'
                    }
                },
                crosshairs: {
                    show: false
                }
            },
            yaxis: {
                min: -50,
                max: 80,
                tickAmount: 6,
                labels: {
                    style: {
                        colors: [labelColor],
                        fontSize: '12px'
                    },
                    formatter: function (val) {
                        return parseInt(val) + "K"
                    }
                }
            },
            fill: {
                opacity: 1
            },
            states: {
                normal: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                hover: {
                    filter: {
                        type: 'none',
                        value: 0
                    }
                },
                active: {
                    allowMultipleDataPointsSelection: false,
                    filter: {
                        type: 'none',
                        value: 0
                    }
                }
            },
            tooltip: {
                style: {
                    fontSize: '12px',
                    borderRadius: 4
                },
                y: {
                    formatter: function (val) {
                        if (val > 0) {
                            return val + 'K';
                        } else {
                            return Math.abs(val) + 'K';
                        }
                    }
                }
            },
            colors: [baseColor, negativeColor],
            grid: {
                borderColor: borderColor,
                strokeDashArray: 4,               
                yaxis: {
                    lines: {
                        show: true
                    }
                }
            }
        };

        chart.self = new ApexCharts(element, options);

        // Set timeout to properly get the parent elements width
        setTimeout(function() {
            chart.self.render();
            chart.rendered = true;
        }, 200); 
    }

    // Public methods
    return {
        init: function () {
            initChart();

            // Update chart on theme mode change
            KTThemeMode.on("kt.thememode.change", function() {                
                if (chart.rendered) {
                    chart.self.destroy();
                }

                initChart(chart);
            });
        }   
    }
}();

// Webpack support
if (typeof module !== 'undefined') {
    module.exports = KTChartsWidget1;
}

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTChartsWidget1.init();
});
