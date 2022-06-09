
 function SaveFileSql(filename, basefile64) {
    let link = document.createElement('a');
    link.download = filename;
    link.href = 'data:application/sql;base64,' + basefile64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}


function printpayments() {
    let doc = document.getElementById('dvprinter').innerHTML;
    let paper = window.open('', '', 'height=720,width=1280');
    paper.document.write('<html>');
    paper.document.write('<head> <br />');
    paper.document.write('<link rel="stylesheet" href="/bootstrap/css/bootstrap.min.css" />');
    paper.document.write('<link href="/css/site.css" rel="stylesheet" />');
    paper.document.write('</head>');
    paper.document.write('<body> <br />');
    paper.document.write('<div style="direction:rtl">');
    paper.document.write(doc);
    paper.document.write('</div>')
    paper.document.write('<script src="/jquery/jquery.min.js"></script>');
    paper.document.write('<script src="/bootstrap/js/bootstrap.min.js"></script>');
    paper.document.write('</body>');
    paper.document.write('</html>');
    paper.print();
    paper.close();
    
}