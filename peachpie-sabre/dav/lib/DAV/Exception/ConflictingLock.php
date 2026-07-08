<?php


namespace Sabre\DAV\Exception;

use Sabre\DAV;

/**
 * ConflictingLock.
 *
 * Similar to  the Locked exception, this exception thrown when a LOCK request
 * was made, on a resource which was already locked
 *
 * @copyright Copyright (C) fruux GmbH (https://fruux.com/)
 * @author Evert Pot (http://evertpot.com/)
 * @license http://sabre.io/license/ Modified BSD License
 */
class ConflictingLock extends Locked
{
    /**
     * This method allows the exception to include additional information into the WebDAV error response.
     */
    public function serialize(DAV\Server $server, \Sabre\Xml\Writer $writer)
    {
        if ($this->lock) {
            $writer->writeElement('{DAV:}no-conflicting-lock', [
                '{DAV:}href' => $this->lock->uri,
            ]);
        }
    }
}
