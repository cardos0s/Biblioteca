const express = require('express');
const path = require('path');
const cors = require('cors');
const app = express();
const port = 3010;

const booksRouter = require('./app/routes/books');

app.use(express.json());
app.use(express.urlencoded({extended: true}));
app.use(express.static(path.join(__dirname, 'public')));
app.use(cors());

app.use('/books', booksRouter);

app.listen(process.env.PORT ? process.env.PORT : port, ()=>
{
    console.log('Servidor iniciado na porta: ' + port);
});