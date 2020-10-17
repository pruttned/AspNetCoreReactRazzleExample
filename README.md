# React with SSR + ASP.NET Core example using Razzle

This repository contains code for blog posts [part1](https://nede.dev/blog/integrating-react-into-aspnet-core-using-razzle-with-all-the-goodies-like-ssr-routing-code-splitting-and-hmr-part-1) and [part2](https://nede.dev/blog/integrating-react-into-aspnet-core-using-razzle-with-all-the-goodies-like-ssr-routing-code-splitting-and-hmr-part-2)

# develop

1. Setup SSL dev cert [see](https://docs.microsoft.com/en-us/aspnet/core/security/enforcing-ssl?view=aspnetcore-3.1&tabs=visual-studio#trust-the-aspnet-core-https-development-certificate-on-windows-and-macos)

2. Go to ClientApp and create file `.env.development.local` based on `.env`

1. Run 
```
npm i
```

and then

```
npm run start
```
To start both client and server.
Server is listening on https://localhost:5001 .
