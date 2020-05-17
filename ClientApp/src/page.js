import React, { useEffect, useState } from 'react';
import { withRouter } from 'react-router-dom';

const page = (WrappedComponent) =>
  withRouter(({ staticContext, location }) => {
    const [pageData, setPageData] = useState(null);
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