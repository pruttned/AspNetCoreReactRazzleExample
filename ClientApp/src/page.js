import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';

const page = (WrappedComponent) =>
  ({ staticContext }) => {
    const location = useLocation();

    let initData = null;
    if (staticContext) {
      initData = staticContext.data;
    } else if (window.__ROUTE_DATA__) {
      initData = window.__ROUTE_DATA__;
      delete window.__ROUTE_DATA__;
    }

    if (!staticContext && !initData) {
      useEffect(() => {
        fetch(`data${location.pathname}`)
          .then(r => r.json())
          .then(setPageData);
      }, [location]);
    }

    const [pageData, setPageData] = useState(initData);

    return (
      pageData && <WrappedComponent pageData={pageData}></WrappedComponent>
    );
  };

export default page;