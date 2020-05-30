const nodeExternals = require('webpack-node-externals');
module.exports = {
    modify: (config, { target, dev }, webpack) => {
        if (dev) {
            if (target === 'node') {
                config.plugins = config.plugins.filter(p => p.constructor.name !== 'HotModuleReplacementPlugin');
                config.entry = config.entry.filter(e => e !== 'webpack/hot/poll?300');
            }
            if (target === 'web') {
                config.devServer.https = true;
                config.devServer.pfx = process.env.RAZZLE_PFX;
                config.devServer.pfxPassphrase = process.env.RAZZLE_PFX_PASSPHRASE;
            }
            config.output.publicPath = config.output.publicPath.replace('http://', 'https://');
        } else {
            if (target === 'node') {
                config.externals = [];
            }
        }

        return config;
    },
};