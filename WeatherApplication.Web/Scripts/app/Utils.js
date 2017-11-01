var Utils = (function () {
    var fns = {};

    fns.isEmpty = function (data) {
        if (typeof data === 'string') {
            return (data == null || data === "");
        }
        else {
            return true;
        }
    };   

    fns.pad2 = function (number) {
        number = '0' + Math.floor(number);
        return number.substr(number.length - 2);
    };

    fns.getTime = function (ticks) {
        if (!this.isEmpty(ticks)) {
            var seconds = Math.floor(ticks / 1000);
            console.log(seconds);
            var hour = Math.floor((seconds / 3600) % 24);
            var minute = Math.floor((seconds / 60) % 60);
            var second = seconds % 60;

            var result = this.pad2(hour) + ':' + this.pad2(minute) + ':' + this.pad2(second);
            return result;
        }
        else
            return "";
    };

    return fns;
})();

