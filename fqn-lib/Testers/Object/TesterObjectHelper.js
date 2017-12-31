
"use strict";

var ObjectHelper = require("../../Object/ObjectHelper.js");

class TesterObjectHelper {

    static run() {

        var clone = ObjectHelper.cloneProps(
            {
                p1: "I am P2",
                p2: "I am p2"
            },
            {
                p3: "I am P3",
                p4: "I am p4"
            },
            {
                p5: "I am P5"
            }
        );

        console.log(clone);





    }
}

TesterObjectHelper.run();
