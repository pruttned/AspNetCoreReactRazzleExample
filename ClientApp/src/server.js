import App from './App';
import React from 'react';
import { StaticRouter } from 'react-router-dom';
import { renderToString } from 'react-dom/server';

const assets = require(process.env.RAZZLE_ASSETS_MANIFEST);

const server = (cb, url, data) => {
  const context = { data };
  const markup = renderToString(
    <StaticRouter context={context} location={url}>
      <App />
    </StaticRouter>
  );
  
  cb(null, `<!doctype html>
      <html lang="">
      <head>
          <meta http-equiv="X-UA-Compatible" content="IE=edge" />
          <meta charset="utf-8" />
          <title>Welcome to Razzle</title>
          <meta name="viewport" content="width=device-width, initial-scale=1">
          <script>window.__ROUTE_DATA__=${JSON.stringify(data)}</script>
          ${assets.client.css
      ? `<link rel="stylesheet" href="${assets.client.css}">`
      : ''} 
          ${process.env.NODE_ENV === 'production'
      ? `<script src="${assets.client.js}" defer></script>`
      : `<script src="${assets.client.js}" defer crossorigin></script>`}
      </head>
      <body>
          <div id="root">${markup}</div>
      </body>
    </html>`);
}

export default server;
