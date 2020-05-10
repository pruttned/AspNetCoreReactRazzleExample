module.exports = {
    modify: (config, { target, dev }, webpack) => {
        if (target === 'node' && dev) {
            config.plugins = config.plugins.filter(p => p.constructor.name !== 'HotModuleReplacementPlugin');
            config.entry = config.entry.filter(e => e !== 'webpack/hot/poll?300');
        }
        if (target === 'web' && dev) {
            config.devServer.https = true;
            config.devServer.pfx = '...';
            config.devServer.pfxPassphrase = '...';
            config.output.publicPath=`https://${config.devServer.host}:${config.devServer.port}/`
        }

        return config;
    },
};