import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router-dom';

const page = (WrappedComponent) =>
  withRouter(({ staticContext, location }) => {
    let initData = null;
    if (staticContext) {
      initData = staticContext.data;
    } else if (window.__ROUTE_DATA__) {// We need this so the HTML after hydrate is going to match the server side rendered HTML
      initData = window.__ROUTE_DATA__;
      window.__ROUTE_DATA__ = null; // We need to clear __ROUTE_DATA__, so they are not going to be used for another page during client side routing
    }
    const [pageData, setPageData] = useState(initData);
    if (!pageData) {
      if (!staticContext) {
        fetch(`data${location.pathname}`)
          .then(r => r.json())
          .then(setPageData);
      }
    }
    return (
      pageData && <WrappedComponent pageData={pageData}></WrappedComponent>
    );
  });

export default page;